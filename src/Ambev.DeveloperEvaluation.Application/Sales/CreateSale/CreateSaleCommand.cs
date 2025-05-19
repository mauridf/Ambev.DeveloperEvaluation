using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public DateTime SaleDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<SaleItemDto> Items { get; set; }
    }
}