using Backend.Application.Dtos.Combo;
using Backend.Application.Handlers.Combos.RequestHandlers.Commands;
using Backend.Application.Handlers.Combos.RequestHandlers.Queries;
using Backend.Application.Handlers.Combos.Requests.Commands;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using Moq;

namespace Backend.Api.Tests.Combos;

public class ComboHandlersTests
{
    private readonly Mock<IComboRepository> _mockComboRepository = new();
    private readonly Mock<IProductRepository> _mockProductRepository = new();

    #region CreateComboCommandHandler Tests

    [Fact]
    public async Task Handle_ValidCombo_ShouldCreateSuccessfully()
    {
        // Arrange
        var handler = new CreateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var product1Id = Guid.NewGuid();
        var product2Id = Guid.NewGuid();

        var products = new List<Product>
        {
            new() { Id = product1Id, Name = "Product1", Price = 100 },
            new() { Id = product2Id, Name = "Product2", Price = 150 }
        };

        var createComboDto = new CreateComboDto
        {
            Name = "Test Combo",
            Description = "Test Description",
            DiscountPercent = 10,
            ProductIds = [product1Id, product2Id]
        };

        _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => products.Find(p => p.Id == id));

        _mockComboRepository.Setup(x => x.AddAsync(It.IsAny<Combo>()))
            .ReturnsAsync((Combo combo) => combo);

        // Act
        var result = await handler.Handle(new CreateComboCommand(createComboDto), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Combo", result.Name);
        Assert.Equal(250, result.Price); // 100 + 150
        Assert.Equal(10, result.DiscountPercent);
    }

    [Fact]
    public async Task Handle_NonExistentProduct_ShouldThrowException()
    {
        // Arrange
        var handler = new CreateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var invalidProductId = Guid.NewGuid();
        var createComboDto = new CreateComboDto
        {
            Name = "Test Combo",
            ProductIds = [invalidProductId]
        };

        _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Product)null!);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(new CreateComboCommand(createComboDto), CancellationToken.None));
    }

    #endregion

    #region UpdateComboCommandHandler Tests

    [Fact]
    public async Task Handle_ValidUpdate_ShouldUpdateSuccessfully()
    {
        // Arrange
        var handler = new UpdateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var comboId = Guid.NewGuid();
        var productId = Guid.NewGuid();

        var existingCombo = new Combo
        {
            Id = comboId,
            Name = "Old Name",
            Description = "Old Description",
            DiscountPercent = 5,
            Products = new List<Product>()
        };

        var updateDto = new UpdateComboDto
        {
            Id = comboId,
            Name = "New Name",
            Description = "New Description",
            DiscountPercent = 15,
            ProductsIds = [productId]
        };

        _mockComboRepository.Setup(x => x.GetByIdAsync(comboId))
            .ReturnsAsync(existingCombo);
        _mockProductRepository.Setup(x => x.GetByIdAsync(productId))
            .ReturnsAsync(new Product { Id = productId, Price = 100 });

        // Act
        var result = await handler.Handle(new UpdateComboCommand(updateDto), CancellationToken.None);

        // Assert
        Assert.Equal("New Name", result.Name);
        Assert.Equal("New Description", result.Description);
        Assert.Equal(15, result.DiscountPercent);
    }

    [Fact]
    public async Task Handle_ComboNotFound_ShouldThrowArgumentException()
    {
        // Arrange
        var handler = new UpdateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var nonExistentId = Guid.NewGuid();
        var updateDto = new UpdateComboDto { Id = nonExistentId };

        _mockComboRepository.Setup(x => x.GetByIdAsync(nonExistentId))
            .ReturnsAsync((Combo)null!);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.Handle(new UpdateComboCommand(updateDto), CancellationToken.None));
    }

    #endregion

    #region GetAllCombosQueryHandler Tests

    [Fact]
    public async Task Handle_ValidRequest_ShouldReturnPaginatedCombos()
    {
        // Arrange
        var handler = new GetAllCombosQueryHandler(_mockComboRepository.Object);
        var comboId = Guid.NewGuid();
        var combos = new List<Combo>
        {
            new() {
                Id = comboId,
                Name = "Combo1",
                Products = new List<Product>(),
                IsActive = true
            }
        };

        _mockComboRepository.Setup(x => x.GetAllAsync(1, 10))
            .ReturnsAsync(combos);
        _mockComboRepository.Setup(x => x.GetCountAsync())
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(new GetAllCombosQuery(1, 10), CancellationToken.None);

        // Assert
        Assert.Single(result.Items!);
        Assert.Equal(1, result.TotalCount);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
    }

    #endregion

    #region GetAllCombosWithDiscountCommandHandler Tests

    [Fact]
    public async Task Handle_ShouldReturnOnlyCombosWithDiscount()
    {
        // Arrange
        var handler = new GetAllCombosWithDiscountCommandHandler(_mockComboRepository.Object);
        var combo1Id = Guid.NewGuid();
        var combo2Id = Guid.NewGuid();

        var combos = new List<Combo>
        {
            new() {
                Id = combo1Id,
                Name = "Combo1",
                DiscountPercent = 10,
                Price = 100,
                Products = new List<Product>()
            },
            new() {
                Id = combo2Id,
                Name = "Combo2",
                DiscountPercent = 0,
                Price = 100,
                Products = new List<Product>()
            }
        };

        _mockComboRepository.Setup(x => x.GetAllAsync(1, 10))
            .ReturnsAsync(combos);
        _mockComboRepository.Setup(x => x.GetCountAsync())
            .ReturnsAsync(2);

        // Act
        var result = await handler.Handle(new GetAllCombosWithDiscountCommand(1, 10), CancellationToken.None);

        // Assert
        Assert.Single(result.Items!);
        Assert.Equal(90, result.Items!.First().PriceWithDiscount); // 100 * (1 - 10/100)
    }

    [Fact]
    public async Task Handle_EmptyDiscountList_ShouldReturnEmptyResult()
    {
        // Arrange
        var handler = new GetAllCombosWithDiscountCommandHandler(_mockComboRepository.Object);
        var combos = new List<Combo>
        {
            new() {
                Id = Guid.NewGuid(),
                Name = "Combo1",
                DiscountPercent = 0,
                Products = new List<Product>()
            }
        };

        _mockComboRepository.Setup(x => x.GetAllAsync(1, 10))
            .ReturnsAsync(combos);
        _mockComboRepository.Setup(x => x.GetCountAsync())
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(new GetAllCombosWithDiscountCommand(1, 10), CancellationToken.None);

        // Assert
        Assert.Empty(result.Items!);
    }

    #endregion

    #region GetComboByIdQueryHandler Tests

    [Fact]
    public async Task Handle_ExistingId_ShouldReturnCombo()
    {
        // Arrange
        var handler = new GetComboByIdQueryHandler(_mockComboRepository.Object);
        var comboId = Guid.NewGuid();
        var combo = new Combo
        {
            Id = comboId,
            Name = "Test Combo",
            Products = new List<Product>()
        };

        _mockComboRepository.Setup(x => x.GetByIdAsync(comboId))
            .ReturnsAsync(combo);

        // Act
        var result = await handler.Handle(new GetComboByIdQuery(comboId), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(comboId, result.Id);
        Assert.Equal("Test Combo", result.Name);
    }

    [Fact]
    public async Task Handle_NonExistentId_ShouldThrowException()
    {
        // Arrange
        var handler = new GetComboByIdQueryHandler(_mockComboRepository.Object);
        var nonExistentId = Guid.NewGuid();

        _mockComboRepository.Setup(x => x.GetByIdAsync(nonExistentId))
            .ReturnsAsync((Combo)null!);

        // Act & Assert
        await Assert.ThrowsAsync<NullReferenceException>(() =>
            handler.Handle(new GetComboByIdQuery(nonExistentId), CancellationToken.None));
    }

    #endregion

    #region DeleteComboCommandHandler Tests

    [Fact]
    public async Task Handle_ValidId_ShouldDeleteSuccessfully()
    {
        // Arrange
        var handler = new DeleteComboCommandHandler(_mockComboRepository.Object);
        var comboId = Guid.NewGuid();

        _mockComboRepository.Setup(x => x.DeleteAsync(comboId))
            .ReturnsAsync(true);

        // Act
        var result = await handler.Handle(new DeleteComboCommand(comboId), CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Handle_InvalidId_ShouldReturnFalse()
    {
        // Arrange
        var handler = new DeleteComboCommandHandler(_mockComboRepository.Object);
        var nonExistentId = Guid.NewGuid();

        _mockComboRepository.Setup(x => x.DeleteAsync(nonExistentId))
            .ReturnsAsync(false);

        // Act
        var result = await handler.Handle(new DeleteComboCommand(nonExistentId), CancellationToken.None);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Additional Edge Cases

    [Fact]
    public async Task Handle_UpdateCombo_WithNullProducts_ShouldKeepExistingProducts()
    {
        // Arrange
        var handler = new UpdateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var comboId = Guid.NewGuid();
        var existingProducts = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Price = 100 }
        };

        var existingCombo = new Combo
        {
            Id = comboId,
            Name = "Test Combo",
            Products = existingProducts,
            Price = 100
        };

        var updateDto = new UpdateComboDto
        {
            Id = comboId,
            Name = "Updated Name",
            ProductsIds = null
        };

        _mockComboRepository.Setup(x => x.GetByIdAsync(comboId))
            .ReturnsAsync(existingCombo);

        // Act
        var result = await handler.Handle(new UpdateComboCommand(updateDto), CancellationToken.None);

        // Assert
        Assert.Equal(existingProducts.Count, result.Products.Count);
        Assert.Equal(100, result.Price);
    }

    [Fact]
    public async Task Handle_CreateCombo_WithZeroProducts_ShouldThrowException()
    {
        // Arrange
        var handler = new CreateComboCommandHandler(_mockComboRepository.Object, _mockProductRepository.Object);
        var createComboDto = new CreateComboDto
        {
            Name = "Test Combo",
            ProductIds = new List<Guid>() // Empty product list
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            handler.Handle(new CreateComboCommand(createComboDto), CancellationToken.None));
    }

    #endregion
}
