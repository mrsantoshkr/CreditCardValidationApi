using CreditCardValidationApi.Models;
using CreditCardValidationApi.Repository;
using CreditCardValidationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _service;

        public CreditCardController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpPost("validate")]
        public ActionResult<bool> ValidateCreditCard([FromBody] CreditCardModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CreditCardNumber))
            {
                return BadRequest("Credit card number is required.");
            }

            // Deliberately throw an exception to test the error handling middleware
            //throw new Exception("Test exception");

            bool isValid = _service.ValidateCreditCard(model.CreditCardNumber);
            return Ok(isValid);
        }
    }


}
