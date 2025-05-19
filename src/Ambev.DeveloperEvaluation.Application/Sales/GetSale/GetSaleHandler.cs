using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId);

            if (sale == null)
                return null;

            return new GetSaleResult
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                CustomerId = sale.CustomerId,
                CustomerName = sale.CustomerName,
                BranchId = sale.BranchId,
                BranchName = sale.BranchName,
                TotalAmount = sale.TotalAmount,
                Status = sale.Status,
                Items = sale.Items.Select(i => new GetSaleResult.SaleItemResult
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    DiscountApplied = i.DiscountApplied,
                    TotalItem = i.TotalItem,
                    IsCancelled = i.IsCancelled
                })
            };
        }
    }
}