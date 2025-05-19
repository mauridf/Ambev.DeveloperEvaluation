using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleService _saleService;
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public UpdateSaleHandler(
            ISaleService saleService,
            ISaleRepository saleRepository,
            IMediator mediator)
        {
            _saleService = saleService;
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId);
            if (sale == null)
                throw new DomainException("Sale not found");

            // Adicionar novos itens
            foreach (var itemDto in request.ItemsToAdd)
            {
                var item = new SaleItem(
                    itemDto.ProductId,
                    itemDto.ProductName,
                    itemDto.Quantity,
                    itemDto.UnitPrice);

                sale.AddItem(item);
            }

            // Remover itens
            foreach (var itemId in request.ItemsToRemove)
            {
                sale.RemoveItem(itemId);
            }

            await _saleService.UpdateSaleAsync(sale);

            return new UpdateSaleResult
            {
                SaleId = sale.Id,
                NewTotalAmount = sale.TotalAmount,
                ItemsCount = sale.Items.Count
            };
        }
    }
}