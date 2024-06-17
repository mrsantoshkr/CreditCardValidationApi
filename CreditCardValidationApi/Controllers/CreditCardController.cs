using CreditCardValidationApi.Models;
using CreditCardValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        [HttpPost("validate")]
        public ActionResult<bool> ValidateCreditCard([FromBody] CreditCardModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CreditCardNumber))
            {
                return BadRequest("Credit card number is required.");
            }

            bool isValid = LuhnValidator.IsValid(model.CreditCardNumber);
            return Ok(isValid);
        }
    }
}
