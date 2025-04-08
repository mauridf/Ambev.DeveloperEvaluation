using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Sale ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemDtoValidator());
    }
}

public class UpdateSaleItemDtoValidator : AbstractValidator<UpdateSaleItemDto>
{
    public UpdateSaleItemDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("The quantity must be greater than zero.");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("The unit price must be greater than zero.");
    }
}
