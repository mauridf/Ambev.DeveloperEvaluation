using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

/// <summary>
/// Profile for mapping between Sale entity and GetAllSaleResult
/// </summary>
public class GetAllSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetAllSales operation
    /// </summary>
    public GetAllSalesProfile()
    {
        CreateMap<Sale, GetAllSalesResult>();
    }
}
