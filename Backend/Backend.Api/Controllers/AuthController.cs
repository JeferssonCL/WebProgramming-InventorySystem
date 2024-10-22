
using AutoMapper;
using Backend.Application.Dtos.User;
using Backend.Application.Handlers.Auth.Request.Commands;
using Backend.Application.Services.Auth.Interfaces;
using Backend.Domain.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IJwtDecoder _jwtDecoder;
    public AuthController(IMediator mediator, IMapper mapper, IJwtDecoder jwtDecoder)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtDecoder = jwtDecoder;
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserDto>> SignUp(UserRegisterCommand userRegisterCommand)
    {
        User user = await _mediator.Send(userRegisterCommand);
        return Ok(_mapper.Map<UserDto>(user));
    }

    [HttpGet("token")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        var authHeader = Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            return BadRequest("Token not present or incorrect format.");
        }

        var token = authHeader.Substring("Bearer ".Length).Trim();

        var authToken = _jwtDecoder.DecodeJwtToken(token);

        if (authToken == null)
        {
            return BadRequest("The token could not be processed.");
        }

        return Ok(authToken);
    }


}
