using System.ComponentModel.DataAnnotations;

namespace DiplomaCRM.Models
{
    // Класс для создания менеджера
    public class ManagerModel
    {
        [Required(ErrorMessage = "Фамилия сотрудника обязательна")]
        [MaxLength(40, ErrorMessage = "Фамилия не может быть такой длинной")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя сотрудника обязательно")]
        [MaxLength(40, ErrorMessage = "Имя не может быть таким длинным")]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Логин для пользователя обязателен")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль для пользователя необходимо сформировать")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int Role { get; set; }
    }
}