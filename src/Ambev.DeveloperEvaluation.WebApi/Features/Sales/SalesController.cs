using Ambev.DeveloperEvaluation.Application.Sales.CancelItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request)
        {
            var command = new CreateSaleCommand
            {
                SaleDate = request.SaleDate,
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                BranchId = request.BranchId,
                BranchName = request.BranchName,
                Items = request.Items
            };

            var result = await _mediator.Send(command);
            return ApiResponse(result);
        }

        [HttpPut("{saleId}")]
        public async Task<IActionResult> UpdateSale(
            [FromRoute] Guid saleId,
            [FromBody] UpdateSaleRequest request)
        {
            var command = new UpdateSaleCommand
            {
                SaleId = saleId,
                ItemsToAdd = request.ItemsToAdd,
                ItemsToRemove = request.ItemsToRemove
            };

            var result = await _mediator.Send(command);
            return ApiResponse(result);
        }

        [HttpDelete("{saleId}")]
        public async Task<IActionResult> CancelSale([FromRoute] Guid saleId)
        {
            var command = new CancelSaleCommand { SaleId = saleId };
            var result = await _mediator.Send(command);
            return ApiResponse(result);
        }

        [HttpDelete("{saleId}/items/{itemId}")]
        public async Task<IActionResult> CancelItem(
            [FromRoute] Guid saleId,
            [FromRoute] Guid itemId)
        {
            var command = new CancelItemCommand
            {
                SaleId = saleId,
                ItemId = itemId
            };

            var result = await _mediator.Send(command);
            return ApiResponse(result);
        }

        [HttpGet("{saleId}")]
        public async Task<IActionResult> GetSale([FromRoute] Guid saleId)
        {
            // Implementação do GET será adicionada na Parte 5
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            // Implementação do GET ALL será adicionada na Parte 5
            return Ok();
        }
    }
}