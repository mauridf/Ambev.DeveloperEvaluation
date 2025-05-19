using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        public Guid SaleId { get; set; }
        public List<SaleItemDto> ItemsToAdd { get; set; }
        public List<Guid> ItemsToRemove { get; set; }
    }
}