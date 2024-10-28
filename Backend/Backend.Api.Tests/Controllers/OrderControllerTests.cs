using Backend.Api.Controllers;
using Backend.Application.Dtos.checkoutSession;
using Backend.Application.Dtos.Order;
using Backend.Application.Handlers.Orders.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend.Api.Tests.Controllers;

public class OrderControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly OrderController _controller;

    public OrderControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new OrderController(_mediatorMock.Object);
    }

    [Fact]
    public async Task CreateOrder_ReturnsOkResult_WhenOrderIsCreatedSuccessfully()
    {
        // Arrange
        var orderDto = new OrderDTO
        {
            StripeSessionId = "cs_test_123",
            Customer = new CustomerDTO
            {
                Id = "null",
                Address = "Test Address",
                City = "Test City",
                Country = "Test Country"
            }
        };
        var orderId = Guid.NewGuid().ToString();

        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), default))
            .ReturnsAsync(orderId);

        // Act
        var result = await _controller.CreateOrder(orderDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, bool>>(okResult.Value);
        Assert.True(returnValue["result"]);
        _mediatorMock.Verify(x => x.Send(It.Is<CreateOrderCommand>(c =>
            c.OrderToBeCreated.StripeSessionId == orderDto.StripeSessionId), default), Times.Once);
    }

    [Fact]
    public async Task CreateOrder_ReturnsFalse_WhenOrderCreationFails()
    {
        // Arrange
        var orderDto = new OrderDTO
        {
            StripeSessionId = "cs_test_123",
            Customer = new CustomerDTO
            {
                Id = "null",
                Address = "Test Address",
                City = "Test City",
                Country = "Test Country"
            }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), default))!
            .ReturnsAsync((string)null!);

        // Act
        var result = await _controller.CreateOrder(orderDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, bool>>(okResult.Value);
        Assert.False(returnValue["result"]);
    }

    [Fact]
    public async Task CreateOrder_HandlesMediatorException()
    {
        // Arrange
        var orderDto = new OrderDTO
        {
            StripeSessionId = "cs_test_123",
            Customer = new CustomerDTO
            {
                Id = "null",
                Address = "Test Address",
                City = "Test City",
                Country = "Test Country"
            }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), default))
            .ThrowsAsync(new Exception("Test exception"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _controller.CreateOrder(orderDto));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task CreateOrder_ValidatesStripeSessionId(string invalidSessionId)
    {
        // Arrange
        var orderDto = new OrderDTO
        {
            StripeSessionId = invalidSessionId,
            Customer = new CustomerDTO
            {
                Id = "null",
                Address = "Test Address",
                City = "Test City",
                Country = "Test Country"
            }
        };

        // Act
        var result = await _controller.CreateOrder(orderDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, bool>>(okResult.Value);
        Assert.False(returnValue["result"]);
    }

    [Fact]
    public async Task CreateOrder_ValidatesCustomerInformation()
    {
        // Arrange
        var orderDto = new OrderDTO
        {
            StripeSessionId = "cs_test_123",
            Customer = null!
        };

        // Act
        var result = await _controller.CreateOrder(orderDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Dictionary<string, bool>>(okResult.Value);
        Assert.False(returnValue["result"]);
    }
}
