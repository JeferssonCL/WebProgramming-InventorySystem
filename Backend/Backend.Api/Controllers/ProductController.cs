using Backend.Application.Handlers.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MerchantService.Application.Dtos;
using Backend.Application.Dtos;
using AutoMapper;
using Backend.Domain.Entities.Concretes;

namespace Backend.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(Guid id)
    {
        var product = mediator.Send(new GetProductQuery(id)).Result;

        if (product == null)
        {
            return NotFound();
        }

        var productDto = mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet]
    public async Task<ActionResult<PageDto<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var query = new GetAllProductsQuery(page, limit);
        (List<Product> products, int total) = await mediator.Send(query);

        var productsDto = mapper.Map<List<ProductDto>>(products);
        PageDto<ProductDto> pageDto = PageDto<ProductDto>.Create(productsDto, total, page, limit);
        return Ok(pageDto);
    }

    /*
    TODO : Out of scope for this project
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _mediator.Send(new CreateProductCommand(product));
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _mediator.Send(new UpdateProductCommand(product));
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        } */
}
