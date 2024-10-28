using Backend.Application.Services.Discounts.Abstracts;
using Backend.Domain.Entities.Concretes;
using Xunit;

namespace ApplicationTest.Discounts;

public class StockAgeDiscountTest
{
    private static StockAgeDiscount CreateStockAgeDiscount()
    {
        return new StockAgeDiscount(new Dictionary<int, double>
        {
            { 9, 30.0 },
            { 6, 20.0 },
            { 3, 10.0 }
        });
    }

    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenProductIsOlderThan9Months()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-10) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(30.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenProductIsBetween6And9Months()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-7) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(20.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenProductIsBetween3And6Months()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-4) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(10.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsZero_WhenProductIsLessThan3MonthsOld()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-2) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(0.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsZero_WhenProductIsExactlyAtLimit()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-3) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(10.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenProductUpdatedInFuture()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(1) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(0.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsZero_WhenProductUpdatedInSameMonth()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(0.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsHighestDiscount_WhenMultipleAgesMeetCondition()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-15) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(30.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenProductJustBeforeLimit()
    {
        // Arrange
        var discountService = CreateStockAgeDiscount();
        var product = new Product { UpdatedAt = DateTime.Now.AddMonths(-3).AddSeconds(1) };

        // Act
        var discount = discountService.GetDiscount(product);

        // Assert
        Assert.Equal(10.0, discount);
    }
}
