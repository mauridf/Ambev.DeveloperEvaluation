using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
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
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleService> _saleServiceMock;
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleServiceMock = new Mock<ISaleService>();
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mediatorMock = new Mock<IMediator>();

            _handler = new CreateSaleHandler(
                _saleServiceMock.Object,
                _saleRepositoryMock.Object,
                _mediatorMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateSale_WhenValidCommand()
        {
            // Arrange
            var command = new CreateSaleCommand
            {
                SaleDate = DateTime.Now,
                CustomerId = "123",
                CustomerName = "Test Customer",
                BranchId = "456",
                BranchName = "Test Branch",
                Items = new List<SaleItemDto>
                {
                    new SaleItemDto
                    {
                        ProductId = "789",
                        ProductName = "Test Product",
                        Quantity = 2,
                        UnitPrice = 10.50m
                    }
                }
            };

            _saleRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Sale>());

            _saleServiceMock.Setup(x => x.CreateSaleAsync(It.IsAny<Sale>()))
                .ReturnsAsync((Sale s) => s);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.SaleNumber.Should().Be(1);
            _mediatorMock.Verify(x => x.Publish(It.IsAny<SaleCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}