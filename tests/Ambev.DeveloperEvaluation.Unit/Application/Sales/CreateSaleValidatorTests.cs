using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    public class CreateSaleValidatorTests
    {
        private readonly CreateSaleValidator _validator;

        public CreateSaleValidatorTests()
        {
            _validator = new CreateSaleValidator();
        }

        [Fact]
        public void Should_HaveError_When_CustomerNameIsEmpty()
        {
            var model = new CreateSaleCommand { CustomerName = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CustomerName);
        }

        [Fact]
        public void Should_HaveError_When_ItemsIsEmpty()
        {
            var model = new CreateSaleCommand { Items = new List<SaleItemDto>() };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Items);
        }
    }
}