using Backend.Application.Handlers.Product.Requests.Queries;
using Backend.Application.Dtos.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MerchantService.Application.Dtos;
using Backend.Application.Handlers.Product.Requests.Commands;

namespace Backend.Application.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(Guid id)
        {
            var product = _mediator.Send(new GetProductQuery(id));

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<PageDto<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var query = new GetAllProductsQuery(page, limit);
            var products = await _mediator.Send(query);

            return Ok(products);
        }


        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            var createdProduct = await _mediator.Send(new CreateProductCommand(productDto));
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var updatedProduct = await _mediator.Send(new UpdateProductCommand(productDto));
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}