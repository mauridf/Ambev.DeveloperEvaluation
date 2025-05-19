using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, GetAllSalesResult>
    {
        private readonly ISaleRepository _saleRepository;

        public GetAllSalesHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetAllSalesResult> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync();

            return new GetAllSalesResult
            {
                Sales = sales.Select(s => new GetSaleResult
                {
                    Id = s.Id,
                    SaleNumber = s.SaleNumber,
                    SaleDate = s.SaleDate,
                    CustomerId = s.CustomerId,
                    CustomerName = s.CustomerName,
                    BranchId = s.BranchId,
                    BranchName = s.BranchName,
                    TotalAmount = s.TotalAmount,
                    Status = s.Status,
                    Items = s.Items.Select(i => new GetSaleResult.SaleItemResult
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
                }),
                TotalCount = sales.Count()
            };
        }
    }
}