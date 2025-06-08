using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductMS.Commons.Dtos.Request;
using ProductMS.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ProductMS.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger.LogInformation("ProductsController instantiated");
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            _logger.LogInformation("Received request to create a Product");
            try
            {
                var command = new CreateProductCommand(createProductDto);
                var message = await _mediator.Send(command);
                return Ok(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating product: {Message}", e.Message);
                return StatusCode(500, "Error while creating product.");
            }
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                var command = new UpdateProductCommand(updateProductDto);
                var msg = await _mediator.Send(command);
                return Ok(msg);
            }
            catch (Exception e)
            {
                _logger.LogError("Error updating product: {Message}", e.Message);
                return StatusCode(500, "Error while updating product.");
            }
        }





    }
}
