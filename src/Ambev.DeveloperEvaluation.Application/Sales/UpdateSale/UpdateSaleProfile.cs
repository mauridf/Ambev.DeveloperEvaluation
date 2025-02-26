using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.SaleItems));

        CreateMap<Sale, UpdateSaleResponse>()
            .ForMember(dest => dest.UpdatedSale.CustomerName, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.UpdatedSale.SaleDate, opt => opt.MapFrom(src => src.SaleDate));
    }
}
