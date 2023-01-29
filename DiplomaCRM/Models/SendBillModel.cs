using System.ComponentModel.DataAnnotations;

namespace DiplomaCRM.Models
{
    // Класс для формы выставления счёта
    public class SendBillModel
    {
        public int BilldOrderTypeId { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить название товара или услуги")]
        public string BillOrderNameGoods { get; set; }

        [Required(ErrorMessage = "Количество обязательно")]
        public int BillOrderCountGoods { get; set; }

        [Required(ErrorMessage = "Цена обязательна")]
        public decimal BillOrderPrice { get; set; }
        public decimal BillOrderCost { get; set; }
    }
}