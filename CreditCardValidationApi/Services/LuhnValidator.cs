namespace CreditCardValidationApi.Services
{
    public class LuhnValidator
    {
        public static bool IsValid(string creditCardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                char[] nx = creditCardNumber.ToCharArray();
                int n;
                if (int.TryParse(nx[i].ToString(), out n))
                {
                    if (alternate)
                    {
                        n *= 2;
                        if (n > 9)
                        {
                            n = (n % 10) + 1;
                        }
                    }
                    sum += n;
                    alternate = !alternate;
                }
                else
                {
                    return false;
                }
            }
            return (sum % 10 == 0);
        }
    }
}
