using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleService _saleService;
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public CreateSaleHandler(
            ISaleService saleService,
            ISaleRepository saleRepository,
            IMediator mediator)
        {
            _saleService = saleService;
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var lastSale = (await _saleRepository.GetAllAsync())
                .OrderByDescending(s => s.SaleNumber)
                .FirstOrDefault();

            var saleNumber = lastSale?.SaleNumber + 1 ?? 1;

            var sale = new Sale(
                saleNumber,
                request.SaleDate,
                request.CustomerId,
                request.CustomerName,
                request.BranchId,
                request.BranchName);

            foreach (var itemDto in request.Items)
            {
                var item = new SaleItem(
                    itemDto.ProductId,
                    itemDto.ProductName,
                    itemDto.Quantity,
                    itemDto.UnitPrice);

                sale.AddItem(item);
            }

            await _saleService.CreateSaleAsync(sale);

            await _mediator.Publish(new SaleCreatedEvent(sale), cancellationToken);

            return new CreateSaleResult
            {
                SaleId = sale.Id,
                SaleNumber = sale.SaleNumber,
                TotalAmount = sale.TotalAmount
            };
        }
    }
}