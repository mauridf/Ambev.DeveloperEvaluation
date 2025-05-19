using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly GetSaleHandler _handler;

        public GetSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _handler = new GetSaleHandler(_saleRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSale_WhenExists()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var sale = new Sale(1, DateTime.Now, "1", "Cliente", "1", "Filial");
            sale.AddItem(new SaleItem("1", "Produto", 2, 10m));

            _saleRepositoryMock.Setup(x => x.GetByIdAsync(saleId))
                .ReturnsAsync(sale);

            var command = new GetSaleCommand { SaleId = saleId };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.SaleNumber.Should().Be(1);
            result.Items.Should().HaveCount(1);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenSaleNotFound()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            _saleRepositoryMock.Setup(x => x.GetByIdAsync(saleId))
                .ReturnsAsync((Sale)null);

            var command = new GetSaleCommand { SaleId = saleId };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}