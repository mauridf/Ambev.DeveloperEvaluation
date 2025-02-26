using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleNumber).NotEmpty().Length(1, 50);
            RuleFor(sale => sale.SaleDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(sale => sale.Client).NotEmpty().Length(1, 100);
            RuleFor(sale => sale.Branch).NotEmpty().Length(1, 100);
            RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemRequestValidator());
        }
    }

    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
        {
            RuleFor(item => item.Product).NotEmpty().Length(1, 100);
            RuleFor(item => item.Quantity).GreaterThan(0);
            RuleFor(item => item.UnitPrice).GreaterThan(0);
        }
    }
}
