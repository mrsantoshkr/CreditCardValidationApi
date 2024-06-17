using CreditCardValidationApi.Controllers;
using CreditCardValidationApi.Models;
using CreditCardValidationApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CreditCardValidationApi.Tests.ControllerTests
{
    public class CreditCardControllerTests
    {
        [Fact]
        public void ValidateCreditCard_ValidCard_ReturnsTrue()
        {
            // Arrange
            var mockService = new Mock<ICreditCardService>();
            mockService.Setup(service => service.ValidateCreditCard(It.IsAny<string>())).Returns(true);

            var controller = new CreditCardController(mockService.Object);
            var model = new CreditCardModel { CreditCardNumber = "4111111111111111" };

            // Act
            var result = controller.ValidateCreditCard(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public void ValidateCreditCard_InvalidCard_ReturnsFalse()
        {
            // Arrange
            var mockService = new Mock<ICreditCardService>();
            mockService.Setup(service => service.ValidateCreditCard(It.IsAny<string>())).Returns(false);

            var controller = new CreditCardController(mockService.Object);
            var model = new CreditCardModel { CreditCardNumber = "1234" }; // Invalid card number

            // Act
            var result = controller.ValidateCreditCard(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.False((bool)okResult.Value);
        }

        [Fact]
        public void ValidateCreditCard_EmptyCardNumber_ReturnsBadRequest()
        {
            // Arrange
            var mockService = new Mock<ICreditCardService>();
            var controller = new CreditCardController(mockService.Object);
            var model = new CreditCardModel { CreditCardNumber = null }; // Empty card number

            // Act
            var result = controller.ValidateCreditCard(model);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Credit card number is required.", badRequestResult.Value);
        }
    }
}
