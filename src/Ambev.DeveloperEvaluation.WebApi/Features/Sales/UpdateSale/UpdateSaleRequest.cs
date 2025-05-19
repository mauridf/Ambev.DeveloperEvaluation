using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequest
    {
        public List<SaleItemDto> ItemsToAdd { get; set; }
        public List<Guid> ItemsToRemove { get; set; }
    }

    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.ItemsToAdd).NotNull();
            RuleFor(x => x.ItemsToRemove).NotNull();
        }
    }
}