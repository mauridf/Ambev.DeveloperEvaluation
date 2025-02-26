using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<GetAllSalesRequest, GetAllSalesCommand>();
        CreateMap<GetSaleResponse, GetSaleResult>();
    }
}
