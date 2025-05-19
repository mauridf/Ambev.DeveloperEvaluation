using Ambev.DeveloperEvaluation.Application.Sales.CancelItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CancelItemRequest, CancelItemCommand>();
            CreateMap<CancelItemResult, CancelItemResponse>();

            CreateMap<CancelSaleRequest, CancelSaleCommand>();
            CreateMap<CancelSaleResult, CancelSaleResponse>();

            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
            CreateMap<CreateSaleResult, CreateSaleResponse>();

            CreateMap<GetSaleRequest, GetSaleCommand>();
            CreateMap<GetSaleResult, GetSaleResponse>();
            CreateMap<GetSaleResult.SaleItemResult, GetSaleResponse.SaleItemResponse>();

            CreateMap<GetAllSalesRequest, GetAllSalesCommand>();
            CreateMap<GetAllSalesResult, GetAllSalesResponse>();
        }
    }
}