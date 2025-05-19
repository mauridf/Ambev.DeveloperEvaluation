using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class UpdateSaleHandlerTests
    {
        private readonly Mock<ISaleService> _saleServiceMock;
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UpdateSaleHandler _handler;

        public UpdateSaleHandlerTests()
        {
            _saleServiceMock = new Mock<ISaleService>();
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mediatorMock = new Mock<IMediator>();

            _handler = new UpdateSaleHandler(
                _saleServiceMock.Object,
                _saleRepositoryMock.Object,
                _mediatorMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateSale_WhenValidCommand()
        {
            // Arrange
            var sale = new Sale(1, DateTime.Now, "1", "Customer", "1", "Branch");
            var command = new UpdateSaleCommand
            {
                SaleId = Guid.NewGuid(),
                ItemsToAdd = new List<SaleItemDto>
                {
                    new SaleItemDto
                    {
                        ProductId = "1",
                        ProductName = "New Product",
                        Quantity = 3,
                        UnitPrice = 15.00m
                    }
                },
                ItemsToRemove = new List<Guid>()
            };

            _saleRepositoryMock.Setup(x => x.GetByIdAsync(command.SaleId))
                .ReturnsAsync(sale);

            _saleServiceMock.Setup(x => x.UpdateSaleAsync(It.IsAny<Sale>()))
                .ReturnsAsync((Sale s) => s);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.ItemsCount.Should().Be(1);
            _mediatorMock.Verify(x => x.Publish(It.IsAny<SaleModifiedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}