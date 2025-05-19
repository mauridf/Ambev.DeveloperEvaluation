using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleRequest
    {
        public Guid SaleId { get; set; }
    }

    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        public GetSaleRequestValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty();
        }
    }
}