using AutoMapper;
using Backend.Application.Dtos;
using Backend.Application.Handlers.Combos.Requests.Queries;
using Backend.Domain.Entities.Concretes;
using MediatR;
using MerchantService.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController(IMapper mapper, IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<PageDto<ProductDto>>> GetAllDiscountProducts([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var query = new GetAllDiscountProductsQuery(page, limit);
        (List<Product> products, int total) = await mediator.Send(query);

        var productsDto = mapper.Map<List<ProductDto>>(products) ?? [];
        var pageDto = PageDto<ProductDto>.Create(productsDto, total, page, limit);
        return Ok(pageDto);
    }

}
