using System.ComponentModel.DataAnnotations;

namespace DiplomaCRM.Models
{
    // Класс для формы изменения/добавления клиента
    public class ClientAddEditModel
    {
        // [] - Аннотации к данным с сообщением ошибки при неправильном вводе
        [Required(ErrorMessage = "Наименование обязательно")]
        public string ClientName { get; set; }

        public int ClientType { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ClientPhone { get; set; }

        [MaxLength(350, ErrorMessage = "Слишком длинный адрес")]
        public string ClientAddress { get; set; }

        public int ClientEmployee { get; set; }
    }
}