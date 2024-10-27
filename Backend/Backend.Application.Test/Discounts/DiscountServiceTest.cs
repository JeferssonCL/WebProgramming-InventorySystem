using Backend.Application.Services.Discounts.Concretes;
using Backend.Application.Services.Discounts.Interfaces;
using Backend.Domain.Entities.Concretes;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace Backend.Application.Test.Discounts
{
    public class DiscountServiceTest
    {
        [Fact]
        public void ApplyDiscount_ReturnsHighestDiscount()
        {
            // Arrange
            var mockPercentageDiscount = new Mock<IDiscount>();
            mockPercentageDiscount.Setup(d => d.GetDiscount(It.IsAny<Product>())).Returns(10.0); // 10% discount

            var mockFixedDiscount = new Mock<IDiscount>();
            mockFixedDiscount.Setup(d => d.GetDiscount(It.IsAny<Product>())).Returns(5.0); // $5 discount

            var discounts = new List<IDiscount>
            {
                mockPercentageDiscount.Object,
                mockFixedDiscount.Object
            };

            var discountService = new DiscountService(discounts);
            var product = new Product { Price = 100.0 };

            // Act
            var productWithDiscount = discountService.ApplyDiscount(product);

            // Assert
            Assert.Equal(95.0, productWithDiscount.PriceWithDiscount);
            Assert.Equal(5.0, productWithDiscount.DiscountPercentage);
        }

        [Fact]
        public void ApplyDiscount_ReturnsZeroPrice_WhenNoDiscountsAvailable()
        {
            // Arrange
            var discountService = new DiscountService([]);
            var product = new Product { Price = 100.0 };

            // Act
            var productWithDiscount = discountService.ApplyDiscount(product);

            // Assert
            Assert.Equal(100.0, productWithDiscount.PriceWithDiscount);
            Assert.Equal(0.0, productWithDiscount.DiscountPercentage);
        }


        [Fact]
        public void ApplyDiscount_ReturnsZeroPrice_WhenProductPriceIsZero()
        {
            // Arrange
            var discountService = new DiscountService([]);
            var product = new Product { Price = 0.0 };

            // Act
            var productWithDiscount = discountService.ApplyDiscount(product);

            // Assert
            Assert.Equal(0.0, productWithDiscount.PriceWithDiscount);
            Assert.Equal(0.0, productWithDiscount.DiscountPercentage);
        }

        [Fact]
        public void ApplyDiscount_HandlesMultipleDiscounts_ReturnsBestDiscount()
        {
            // Arrange
            var mockDiscount1 = new Mock<IDiscount>();
            mockDiscount1.Setup(d => d.GetDiscount(It.IsAny<Product>())).Returns(15.0);

            var mockDiscount2 = new Mock<IDiscount>();
            mockDiscount2.Setup(d => d.GetDiscount(It.IsAny<Product>())).Returns(10.0);

            var discounts = new List<IDiscount>
            {
                mockDiscount1.Object,
                mockDiscount2.Object
            };

            var discountService = new DiscountService(discounts);
            var product = new Product { Price = 200.0 };

            // Act
            var productWithDiscount = discountService.ApplyDiscount(product);

            // Assert
            Assert.Equal(180.0, productWithDiscount.PriceWithDiscount);
            Assert.Equal(10.0, productWithDiscount.DiscountPercentage);
        }
    }
}
