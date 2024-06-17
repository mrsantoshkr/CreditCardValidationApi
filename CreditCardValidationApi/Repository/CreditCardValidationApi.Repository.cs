using CreditCardValidationApi.Services;

namespace CreditCardValidationApi.Repository
{
    public interface ICreditCardService
    {
        bool ValidateCreditCard(string creditCardNumber);
    }

    public class CreditCardService : ICreditCardService
    {
        public bool ValidateCreditCard(string creditCardNumber)
        {
            bool isValid = LuhnValidator.IsValid(creditCardNumber);
            return isValid;
        }
    }

}
