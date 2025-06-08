using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductMS.Commons.Dtos.Request;
using ProductMS.Application.Commands;
using ProductMS.Application.Queries;
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

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                var command = new DeleteProductCommand(new DeleteProductDto { ProductId = id });
                var message = await _mediator.Send(command);
                return Ok(message);
            }
            catch (Exception e)
            {
                _logger.LogError("Error deleting product: {Message}", e.Message);
                return StatusCode(500, "Error while deleting product.");
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var query = new GetAllProductsQuery();
                var products = await _mediator.Send(query);
                return Ok(products);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting products: {Message}", e.Message);
                return StatusCode(500, "Error while getting products.");
            }
        }
        
        [HttpGet("get-{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                var query = new GetProductQuery(id);
                var product = await _mediator.Send(query);
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting product: {Message}", e.Message);
                return StatusCode(500, "Error while getting product.");
            }
        }
    }
}
git add .
git commit -m "feat(product): UC3114 consult product endpoint"
git push -u origin feature/UC3114-consult-product