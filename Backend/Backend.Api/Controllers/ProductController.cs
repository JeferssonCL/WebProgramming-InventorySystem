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
    public async Task<ActionResult<ProductDto>> GetById(Guid id)
    {
        var product = await mediator.Send(new GetProductQuery(id));
        if (product == null) return NotFound();

        var productDto = mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet]
    public async Task<ActionResult<PageDto<ProductDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var query = new GetAllProductsQuery(page, limit);
        (List<Product> products, int total) = await mediator.Send(query);

        var productsDto = mapper.Map<List<ProductDto>>(products) ?? [];
        var pageDto = PageDto<ProductDto>.Create(productsDto, total, page, limit);
        return Ok(pageDto);
    }
}
