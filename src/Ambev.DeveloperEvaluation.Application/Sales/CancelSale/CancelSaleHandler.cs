using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleService _saleService;

        public CancelSaleHandler(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var success = await _saleService.CancelSaleAsync(request.SaleId);

            return new CancelSaleResult
            {
                SaleId = request.SaleId,
                Success = success
            };
        }
    }
}