using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for creating sales.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.Client).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Items).NotEmpty().WithMessage("The sale must contain at least one item.");

        RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemValidator());
    }
}

/// <summary>
/// Validator for sale items.
/// </summary>
public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemDto>
{
    public CreateSaleItemValidator()
    {
        RuleFor(item => item.Product).NotEmpty().Length(2, 100);
        RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20)
            .WithMessage("The quantity must be between 1 and 20.");
        RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("The unit price must be greater than zero.");

        RuleFor(item => item.Quantity).Custom((quantity, context) =>
        {
            if (quantity >= 4 && quantity < 10)
                context.RootContextData["Discount"] = 0.10m;
            else if (quantity >= 10 && quantity <= 20)
                context.RootContextData["Discount"] = 0.20m;
            else
                context.RootContextData["Discount"] = 0m;
        });
    }
}
