
using AutoMapper;
using Backend.Application.Dtos.User;
using Backend.Application.Handlers.Auth.Request.Commands;
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
    public AuthController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserDto>> SignUp(UserRegisterCommand userRegisterCommand)
    {
        User user = await _mediator.Send(userRegisterCommand);

        return Ok(_mapper.Map<UserDto>(user));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginCommand request)
    {
        var jwtToken = await _mediator.Send(request);
        if (string.IsNullOrEmpty(jwtToken))
        {
            return Unauthorized();
        }
        Response.Headers.Append("Authorization", $"Bearer {jwtToken}");

        return Ok(new { Message = "User logged in successfully." });
    }

    [HttpGet("token")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        return Ok();
    }

}
