/*


TODO : Make test when test controllers are needed
using AutoMapper;
using Backend.Api.Controllers;
using Backend.Application.Dtos;
using Backend.Application.Handlers.Products.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using MediatR;
using MerchantService.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend.Api.Tests.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapperMock = new Mock<IMapper>();
        _controller = new ProductController(_mediatorMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenProductExists()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Name = "Test Product" };
        var productDto = new ProductDto { Id = productId, Name = "Test Product" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductQuery>(), default))
            .ReturnsAsync(product);
        _mapperMock.Setup(m => m.Map<ProductDto>(product))
            .Returns(productDto);

        // Act
        var result = await _controller.GetById(productId); // No changes needed here

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedDto = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(productId, returnedDto.Id);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = Guid.NewGuid();

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductQuery>(), default))
            .ReturnsAsync((Product)null!);

        // Act
        var result = await _controller.GetById(productId); // No changes needed here

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetAll_ReturnsPagedProductList()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1" },
            new() { Id = Guid.NewGuid(), Name = "Product 2" }
        };
        var productDtos = new List<ProductDto>
        {
            new() { Id = products[0].Id, Name = "Product 1" },
            new() { Id = products[1].Id, Name = "Product 2" }
        };
        var total = products.Count;

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default))
            .ReturnsAsync((products, total));
        _mapperMock.Setup(m => m.Map<List<ProductDto>>(products))
            .Returns(productDtos);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var pageDto = Assert.IsType<PageDto<ProductDto>>(okResult.Value);
        Assert.Equal(total, pageDto.TotalItems);
        Assert.Equal(2, pageDto.Data.Count());
    }

    [Fact]
    public async Task GetAll_ReturnsEmptyList_WhenNoProducts()
    {
        // Arrange
        var products = new List<Product>();
        var total = 0;

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default))
            .ReturnsAsync((products, total));

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var pageDto = Assert.IsType<PageDto<ProductDto>>(okResult.Value);
        Assert.Empty(pageDto.Data);
        Assert.Equal(0, pageDto.TotalItems);
    }

    [Fact]
    public async Task GetById_ValidatesMediatorQuery()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Name = "Test Product" };
        var productDto = new ProductDto { Id = productId, Name = "Test Product" };

        _mediatorMock.Setup(m => m.Send(It.Is<GetProductQuery>(q => q.Id == productId), default))
            .ReturnsAsync(product);
        _mapperMock.Setup(m => m.Map<ProductDto>(product))
            .Returns(productDto);

        // Act
        await _controller.GetById(productId);

        // Assert
        _mediatorMock.Verify(
            x => x.Send(It.Is<GetProductQuery>(q => q.Id == productId), default),
            Times.Once);
    }

    [Theory]
    [InlineData(0, 10)] // Invalid page
    [InlineData(1, 0)]  // Invalid limit
    [InlineData(-1, 5)] // Negative page
    [InlineData(1, -5)] // Negative limit
    public async Task GetAll_HandlesInvalidPaginationParameters(int page, int limit)
    {
        // Arrange
        var products = new List<Product>();
        var total = 0;

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default))
            .ReturnsAsync((products, total));

        // Act
        var result = await _controller.GetAll(page, limit);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var pageDto = Assert.IsType<PageDto<ProductDto>>(okResult.Value);
        Assert.Empty(pageDto.Data);
        Assert.Equal(0, pageDto.TotalItems);
    }

    [Fact]
    public async Task GetById_ValidatesMapper()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product
        {
            Id = productId,
            Name = "Test Product",
            Description = "Test Description",
            Brand = "Test Brand",
            Price = 99.99
        };
        var productDto = new ProductDto
        {
            Id = productId,
            Name = "Test Product",
            Description = "Test Description",
            Brand = "Test Brand",
            Price = 99.99
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductQuery>(), default))
            .ReturnsAsync(product);
        _mapperMock.Setup(m => m.Map<ProductDto>(product))
            .Returns(productDto);

        // Act
        var result = await _controller.GetById(productId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedDto = Assert.IsType<ProductDto>(okResult.Value);
        Assert.Equal(product.Id, returnedDto.Id);
        Assert.Equal(product.Name, returnedDto.Name);
        Assert.Equal(product.Description, returnedDto.Description);
        Assert.Equal(product.Brand, returnedDto.Brand);
        Assert.Equal(product.Price, returnedDto.Price);

        _mapperMock.Verify(x => x.Map<ProductDto>(product), Times.Once);
    }
}
 */
