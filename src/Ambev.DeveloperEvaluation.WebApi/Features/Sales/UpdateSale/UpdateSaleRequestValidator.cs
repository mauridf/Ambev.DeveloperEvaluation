using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Sale ID is required.");
        RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Customer name is required.");
        RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale date is required.");
        RuleForEach(x => x.SaleItems).ChildRules(items =>
        {
            items.RuleFor(i => i.SaleItemId).NotEmpty().WithMessage("Sale item ID is required.");
            items.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            items.RuleFor(i => i.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        });
    }
}
