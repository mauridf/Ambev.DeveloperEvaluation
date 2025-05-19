using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public DateTime SaleDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<SaleItemDto> Items { get; set; }
    }

    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.SaleDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.CustomerId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.BranchId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BranchName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}