using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResponse>
{
    public Guid SaleId { get; set; }
    public string CustomerName { get; set; }
    public DateTime SaleDate { get; set; }
    public List<UpdateSaleItemCommand> SaleItems { get; set; } = new List<UpdateSaleItemCommand>();
}
