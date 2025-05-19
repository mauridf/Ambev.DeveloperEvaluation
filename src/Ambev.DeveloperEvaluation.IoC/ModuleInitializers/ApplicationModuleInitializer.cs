using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Application.Sales.CancelItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Events;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        // Sales
        builder.Services.AddScoped<IRequestHandler<CreateSaleCommand, CreateSaleResult>, CreateSaleHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateSaleCommand, UpdateSaleResult>, UpdateSaleHandler>();
        builder.Services.AddScoped<IRequestHandler<CancelSaleCommand, CancelSaleResult>, CancelSaleHandler>();
        builder.Services.AddScoped<IRequestHandler<CancelItemCommand, CancelItemResult>, CancelItemHandler>();

        builder.Services.AddScoped<INotificationHandler<SaleCreatedEvent>, SaleEventsHandler>();
        builder.Services.AddScoped<INotificationHandler<SaleModifiedEvent>, SaleEventsHandler>();
        builder.Services.AddScoped<INotificationHandler<SaleCancelledEvent>, SaleEventsHandler>();
        builder.Services.AddScoped<INotificationHandler<ItemCancelledEvent>, SaleEventsHandler>();

        builder.Services.AddScoped<IRequestHandler<GetSaleCommand, GetSaleResult>, GetSaleHandler>();
        builder.Services.AddScoped<IRequestHandler<GetAllSalesCommand, GetAllSalesResult>, GetAllSalesHandler>();
        builder.Services.AddScoped<AbstractValidator<GetSaleCommand>, GetSaleValidator>();

        // AutoMapper Profiles
        builder.Services.AddAutoMapper(typeof(CreateSaleProfile));
    }
}