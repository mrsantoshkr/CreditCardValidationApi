using System.ComponentModel.DataAnnotations;

namespace CreditCardValidationApi.Models
{
    public class CreditCardModel
    {
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }
    }
}
