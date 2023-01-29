using DiplomaCRM.Context;
using DiplomaCRM.Entities;
using DiplomaCRM.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DiplomaCRM.Authentication
{
    public class WebAuthentication : AuthenticationStateProvider
    {
        // Защищённоё хранилище браузера для хранения токена пользователя
        private readonly ProtectedLocalStorage _protectedLocalStorage;

        // Контекст базы данных для получения данных авторизации пользователя
        private readonly DiplomaCRMContext _dataProviderService;

        // Объект пользователя
        private User user;

        public WebAuthentication(ProtectedLocalStorage protectedLocalStorage, DiplomaCRMContext dataProviderService)
        {
            _protectedLocalStorage = protectedLocalStorage;
            _dataProviderService = dataProviderService;
        }

        // Метод получения информации о токене
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var principal = new ClaimsPrincipal();

            try
            {
                var storedPrincipal = await _protectedLocalStorage.GetAsync<string>("identity");

                if (storedPrincipal.Success)
                {
                    var user = JsonConvert.DeserializeObject<User>(storedPrincipal.Value);
                    var (_, isLookUpSuccess) = LookUpUser(user.Login, user.Password);

                    if (isLookUpSuccess)
                    {
                        var identity = CreateIdentityFromUser(user);
                        principal = new(identity);
                    }
                }
            }
            catch
            {

            }

            return new AuthenticationState(principal);
        }

        // Авторизация
        public async Task LoginAsync(LoginModel model)
        {
            var hashPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            var cryptedPassword = new StringBuilder();
            foreach (var x in hashPassword)
                cryptedPassword.Append(x.ToString("x2"));
            var (userInDatabase, isSuccess) = LookUpUser(model.Login, cryptedPassword.ToString());
            var principal = new ClaimsPrincipal();

            if (isSuccess)
            {
                var identity = CreateIdentityFromUser(userInDatabase);
                principal = new ClaimsPrincipal(identity);
                await _protectedLocalStorage.SetAsync("identity", JsonConvert.SerializeObject(userInDatabase));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        // Выход
        public async Task LogoutAsync()
        {
            await _protectedLocalStorage.DeleteAsync("identity");
            var principal = new ClaimsPrincipal();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        // Создание Claim`ов
        private static ClaimsIdentity CreateIdentityFromUser(User user)
        {
            return new ClaimsIdentity(new Claim[]
            {
                new ("Id", user.Id),
                new (ClaimTypes.Name, user.Name),
                new (ClaimTypes.Hash, user.Password),
                new (ClaimTypes.Role, user.Role)
            }, "Employee");
        }

        // Поиск пользователя в базе данных
        private (User, bool) LookUpUser(string username, string password)
        {
            var result = _dataProviderService.Employees
                .FirstOrDefault(u => username == u.EmployeeLogin && password.ToString() == u.EmployeePassword);
            if (result != null)
            {
                user = new User
                {
                    Id = result.EmployeeId.ToString(),
                    Login = result.EmployeeLogin,
                    Password = result.EmployeePassword,
                    Role = result.EmployeeRole.ToString(),
                    Name = result.EmployeeFirstName
                };
            }

            return (user, result is not null);
        }
    }
}