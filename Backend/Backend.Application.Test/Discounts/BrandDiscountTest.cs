using Backend.Application.Services.Discounts.Concretes;
using Backend.Domain.Entities.Concretes;
using Xunit;

namespace ApplicationTest.Discounts;

public class BrandDiscountTest
{

    private readonly IDictionary<string, double> brands = new Dictionary<string, double>
        {
            { "Paceña", 10.0 },
            { "Taquiña", 5.0 },
            { "Kaiser", 7.5 },
            { "Bock", 8.0 },
            { "Boliviana", 12.0 }
        };
    [Fact]
    public void GetDiscount_ReturnsCorrectDiscount_WhenBrandExists()
    {
    // Arrange
    var brandDiscount = new BrandDiscount(brands);
    var product = new Product { Brand = "Paceña" };

    // Act
    var discount = brandDiscount.GetDiscount(product);

    // Assert
    Assert.Equal(10.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsZero_WhenBrandHasNoDiscount()
    {
        // Arrange
        var brandDiscount = new BrandDiscount(brands);
        var product = new Product { Brand = "NoDiscountBrand" };

        // Act
        var discount = brandDiscount.GetDiscount(product);

        // Assert
        Assert.Equal(0.0, discount);
    }

    [Fact]
    public void GetDiscount_ReturnsZero_WhenDiscountIsExplicitlyZero()
    {
        var brands = new Dictionary<string, double>
        {
            { "Paceña", 10.0 },
            { "Taquiña", 5.0 },
            { "Kaiser", 0.0 },
            { "Bock", 8.0 },
            { "Boliviana", 12.0 }
        };
        // Arrange
        var brandDiscount = new BrandDiscount(brands);
        var product = new Product { Brand = "Kaiser" };

        // Act
        var discount = brandDiscount.GetDiscount(product);

        // Assert
        Assert.Equal(0.0, discount);
    }
}
