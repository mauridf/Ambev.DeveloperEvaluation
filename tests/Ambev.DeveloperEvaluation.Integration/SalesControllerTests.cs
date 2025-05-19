using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class SalesControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public SalesControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetSale_ShouldReturn200_WhenSaleExists()
        {
            // Arrange
            var client = _factory.CreateClient();
            var saleId = Guid.NewGuid();

            // Seed data
            using (var scope = _factory.Services.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<ISaleRepository>();
                var sale = new Sale(1, DateTime.Now, "1", "Cliente", "1", "Filial");
                sale.AddItem(new SaleItem("1", "Produto", 2, 10m));
                await repository.AddAsync(sale);
            }

            // Act
            var response = await client.GetAsync($"/api/sales/{saleId}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<ApiResponseWithData<GetSaleResponse>>();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateSale_ShouldReturn201_WhenValidRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new CreateSaleRequest
            {
                SaleDate = DateTime.Now,
                CustomerId = "1",
                CustomerName = "Cliente",
                BranchId = "1",
                BranchName = "Filial",
                Items = new List<SaleItemDto>
                {
                    new SaleItemDto
                    {
                        ProductId = "1",
                        ProductName = "Produto",
                        Quantity = 2,
                        UnitPrice = 10m
                    }
                }
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/sales", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}