using Ambev.DeveloperEvaluation.Application.Sales.CancelItem;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    /// <summary>
    /// Controller for managing sales operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of SalesController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale
        /// </summary>
        /// <param name="request">The sale creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale(
            [FromBody] CreateSaleRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Detail = e.ErrorMessage,
                        Error = e.ErrorCode
                    }).ToList()
                });
            }

            var command = _mapper.Map<CreateSaleCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(result)
            });
        }

        /// <summary>
        /// Updates an existing sale
        /// </summary>
        /// <param name="saleId">The sale ID</param>
        /// <param name="request">The update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale details</returns>
        [HttpPut("{saleId}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSale(
            [FromRoute] Guid saleId,
            [FromBody] UpdateSaleRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Detail = e.ErrorMessage,
                        Error = e.ErrorCode
                    }).ToList()
                });
            }

            var command = _mapper.Map<UpdateSaleCommand>(request);
            command.SaleId = saleId;
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = true,
                Message = "Sale updated successfully",
                Data = _mapper.Map<UpdateSaleResponse>(result)
            });
        }

        /// <summary>
        /// Cancels an entire sale
        /// </summary>
        /// <param name="request">The cancellation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response</returns>
        [HttpDelete("{saleId}")]
        [ProducesResponseType(typeof(ApiResponseWithData<CancelSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelSale(
            [FromRoute] CancelSaleRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new CancelSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Detail = e.ErrorMessage,
                        Error = e.ErrorCode
                    }).ToList()
                });
            }

            var command = _mapper.Map<CancelSaleCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<CancelSaleResponse>
            {
                Success = true,
                Message = "Sale cancelled successfully",
                Data = _mapper.Map<CancelSaleResponse>(result)
            });
        }

        /// <summary>
        /// Cancels a specific item from a sale
        /// </summary>
        /// <param name="request">The cancellation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response with updated total</returns>
        [HttpDelete("{saleId}/items/{itemId}")]
        [ProducesResponseType(typeof(ApiResponseWithData<CancelItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelItem(
            [FromRoute] CancelItemRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new CancelItemRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => new ValidationErrorDetail
                    {
                        Detail = e.ErrorMessage,
                        Error = e.ErrorCode
                    }).ToList()
                });
            }

            var command = _mapper.Map<CancelItemCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<CancelItemResponse>
            {
                Success = true,
                Message = "Item cancelled successfully",
                Data = _mapper.Map<CancelItemResponse>(result)
            });
        }

        [HttpGet("{saleId}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSale([FromRoute] GetSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.ToErrorDetails()
                });

            var command = _mapper.Map<GetSaleCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sale not found"
                });

            return Ok(new ApiResponseWithData<GetSaleResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = _mapper.Map<GetSaleResponse>(result)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetAllSalesResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSales([FromQuery] GetAllSalesRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<GetAllSalesCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetAllSalesResponse>
            {
                Success = true,
                Message = "Sales retrieved successfully",
                Data = new GetAllSalesResponse
                {
                    Sales = _mapper.Map<IEnumerable<GetSaleResponse>>(result.Sales),
                    TotalCount = result.TotalCount,
                    Page = request.Page,
                    PageSize = request.PageSize
                }
            });
        }
    }
}