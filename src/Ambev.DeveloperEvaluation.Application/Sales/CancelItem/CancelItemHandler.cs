using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItem
{
    public class CancelItemHandler : IRequestHandler<CancelItemCommand, CancelItemResult>
    {
        private readonly ISaleService _saleService;
        private readonly ISaleRepository _saleRepository;

        public CancelItemHandler(
            ISaleService saleService,
            ISaleRepository saleRepository)
        {
            _saleService = saleService;
            _saleRepository = saleRepository;
        }

        public async Task<CancelItemResult> Handle(CancelItemCommand request, CancellationToken cancellationToken)
        {
            var success = await _saleService.CancelSaleItemAsync(request.SaleId, request.ItemId);

            var sale = await _saleRepository.GetByIdAsync(request.SaleId);
            var newTotal = sale?.TotalAmount ?? 0;

            return new CancelItemResult
            {
                SaleId = request.SaleId,
                ItemId = request.ItemId,
                Success = success,
                NewTotalAmount = newTotal
            };
        }
    }
}
