using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");

            RuleFor(x => x.ItemsToAdd)
                .Must(x => x == null || x.Any())
                .WithMessage("When adding items, at least one item must be provided");

            RuleForEach(x => x.ItemsToAdd)
                .ChildRules(item =>
                {
                    item.RuleFor(i => i.ProductId).NotEmpty();
                    item.RuleFor(i => i.ProductName).NotEmpty().MaximumLength(100);
                    item.RuleFor(i => i.Quantity)
                        .GreaterThan(0)
                        .LessThanOrEqualTo(20)
                        .WithMessage("Maximum 20 units per product");
                    item.RuleFor(i => i.UnitPrice)
                        .GreaterThan(0)
                        .WithMessage("Unit price must be positive");
                });
        }
    }
}