using Microsoft.AspNetCore.Mvc;
using AuthTest.Src.Application.Features.Auth.DTOs;
using AuthTest.Src.Application.Features.Auth.Commands;
using MediatR;

namespace AuthTest.Src.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(
            ILogger<AuthController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public async Task<ActionResult> Register(
            [FromBody] RegisterRequest request,
            CancellationToken ct)
        {
            var result = await _mediator.Send(new RegisterCommand(
                request.email,
                request.password
            ), ct);

            return Ok(result);    
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody] LoginRequest request,
            CancellationToken ct)
        {
            var result = await _mediator.Send(new LoginCommand(
                request.email, 
                request.password), ct);

            return Ok(result);
        }
    }
}
     