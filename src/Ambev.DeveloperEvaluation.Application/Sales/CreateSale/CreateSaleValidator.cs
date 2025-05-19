using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.SaleDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Sale date cannot be in the future");

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.BranchId)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.BranchName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Sale must have at least one item");

            RuleForEach(x => x.Items)
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