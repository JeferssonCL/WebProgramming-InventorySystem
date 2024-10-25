using Backend.Api.Controllers;
using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Handlers.CheckoutSession.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend.Api.Tests.Controllers;

public class CheckoutControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly CheckoutController _controller;

    public CheckoutControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CheckoutController(_mediatorMock.Object);
    }

    [Fact]
    public async Task InitCheckoutSession_ReturnsOkResult_WhenSessionIsCreatedSuccessfully()
    {
        // Arrange
        var itemsToBuy = new List<ShoppingCartItemDto>
        {
            new() { Id = Guid.NewGuid(), Quantity = 1 }
        };
        var checkoutSessionId = "cs_test_123";

        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCheckoutSessionCommand>(), default))
            .ReturnsAsync(checkoutSessionId);

        // Act
        var result = await _controller.InitCheckoutSession(itemsToBuy);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, string>>(okResult.Value);
        Assert.Equal(checkoutSessionId, returnValue["id"]);
        _mediatorMock.Verify(x => x.Send(It.Is<CreateCheckoutSessionCommand>(c => c.ShoppingCartList == itemsToBuy), default),
            Times.Once);
    }

    [Fact]
    public async Task InitCheckoutSession_ReturnsBadRequest_WhenItemsToBuyIsNull()
    {
        // Arrange
        List<ShoppingCartItemDto> itemsToBuy = null!;

        // Act
        var result = await _controller.InitCheckoutSession(itemsToBuy);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task InitCheckoutSession_ReturnsBadRequest_WhenItemsToBuyIsEmpty()
    {
        // Arrange
        var itemsToBuy = new List<ShoppingCartItemDto>();

        // Act
        var result = await _controller.InitCheckoutSession(itemsToBuy);

        // Assert
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task InitCheckoutSession_HandlesMediatorException()
    {
        // Arrange
        var itemsToBuy = new List<ShoppingCartItemDto>
        {
            new() { Id = Guid.NewGuid(), Quantity = 1 }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCheckoutSessionCommand>(), default))
            .ThrowsAsync(new Exception("Test exception"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<Exception>(() => _controller.InitCheckoutSession(itemsToBuy));
        Assert.Equal("Test exception", exception.Message);
    }
}
