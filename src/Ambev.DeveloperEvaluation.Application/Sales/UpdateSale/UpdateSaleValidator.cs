using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required.");
        RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Customer name is required.");
        RuleFor(x => x.SaleDate).NotEmpty().WithMessage("Sale date is required.");
        RuleForEach(x => x.SaleItems).SetValidator(new UpdateSaleItemValidator());
    }
}

public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemCommand>
{
    public UpdateSaleItemValidator()
    {
        RuleFor(x => x.SaleItemId).NotEmpty().WithMessage("Sale Item ID is required.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
