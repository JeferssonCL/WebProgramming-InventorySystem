using Backend.Api.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend.Api.Tests.Controllers;

public class ErrorControllerTests
{
    private readonly Mock<IExceptionHandler> _mockExceptionHandler;
    private readonly ErrorController _errorController;

    public ErrorControllerTests()
    {
        _mockExceptionHandler = new Mock<IExceptionHandler>();
        _errorController = new ErrorController(_mockExceptionHandler.Object);
    }

    [Fact]
    public async Task HandleError_ShouldCallTryHandleAsync_WhenErrorExists()
    {
        // Arrange
        var exception = new Exception("Test exception");
        var httpContext = new DefaultHttpContext();
        httpContext.Features.Set<IExceptionHandlerFeature>(new ExceptionHandlerFeature
        {
            Error = exception
        });

        _errorController.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        // Act
        await _errorController.HandleError(CancellationToken.None);

        // Assert
        _mockExceptionHandler.Verify(x => x.TryHandleAsync(httpContext, exception, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task HandleError_ShouldNotCallTryHandleAsync_WhenNoErrorExists()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Features.Set<IExceptionHandlerFeature>(null); // No error present

        _errorController.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext
        };

        // Act
        await _errorController.HandleError(CancellationToken.None);

        // Assert
        _mockExceptionHandler.Verify(
            x => x.TryHandleAsync(It.IsAny<HttpContext>(), It.IsAny<Exception>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
}

// Mock implementation of IExceptionHandlerFeature for testing
public class ExceptionHandlerFeature : IExceptionHandlerFeature
{
    public Exception Error { get; set; }
}
