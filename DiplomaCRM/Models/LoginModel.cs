using System.ComponentModel.DataAnnotations;

namespace DiplomaCRM.Models
{
    // Класс для авторизации пользователя
    public class LoginModel
    {
        [Required(ErrorMessage = "Необходимо ввести логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}