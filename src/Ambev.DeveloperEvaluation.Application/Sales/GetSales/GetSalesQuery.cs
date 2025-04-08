using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesQuery : IRequest<List<GetSalesResult>>
{
}
