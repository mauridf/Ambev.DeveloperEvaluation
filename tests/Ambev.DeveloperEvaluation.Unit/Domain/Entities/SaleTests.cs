using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void AddItem_ShouldApplyDiscount_WhenQuantityBetween4And9()
        {
            // Arrange
            var sale = new Sale(1, DateTime.Now, "1", "Cliente", "1", "Filial");
            var item = new SaleItem("1", "Produto", 5, 10m);

            // Act
            sale.AddItem(item);

            // Assert
            Assert.Equal(45m, sale.TotalAmount); // 5 * 10 * 0.9 (10% discount)
        }

        [Fact]
        public void AddItem_ShouldThrowException_WhenQuantityExceeds20()
        {
            // Arrange
            var sale = new Sale(1, DateTime.Now, "1", "Cliente", "1", "Filial");
            var item = new SaleItem("1", "Produto", 21, 10m);

            // Act & Assert
            Assert.Throws<DomainException>(() => sale.AddItem(item));
        }

        [Fact]
        public void CancelItem_ShouldUpdateTotalAmount()
        {
            // Arrange
            var sale = new Sale(1, DateTime.Now, "1", "Cliente", "1", "Filial");
            var item = new SaleItem("1", "Produto", 2, 10m);
            sale.AddItem(item);

            // Act
            sale.CancelItem(item.Id);

            // Assert
            Assert.Equal(0m, sale.TotalAmount);
        }
    }
}