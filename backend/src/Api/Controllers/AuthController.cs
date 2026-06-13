using Microsoft.AspNetCore.Mvc;
using AuthTest.Src.Application.Features.Auth.DTOs;
using AuthTest.Src.Application.Features.Auth.Commands;
using MediatR;

namespace AuthTest.Src.Api.Controllers
{
    [Route("api/auth")]
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
        [Route("register")]
        public async Task<ActionResult> Register(
            [FromBody] RegisterRequest request,
            CancellationToken ct)
        {

            var result = await _mediator.Send(new RegisterCommand(
                request.firstName,
                request.lastName,
                request.login,
                request.phone,
                request.email,
                request.password
            ), ct);

            return Ok(result);    
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody] LoginRequest request,
            CancellationToken ct)
        {
            var result = await _mediator.Send(new LoginCommand(
                request.login, 
                request.password), ct);

            return Ok(result);
        }

        [HttpPost]
        [Route("login-by-email")]
        public async Task<ActionResult<LoginResponse>> EmailLogin(
            [FromBody] EmailLoginRequest request,
            CancellationToken ct)
        {
            var result = await _mediator.Send(new EmailLoginCommand(
                request.email,
                request.password), ct);

            return Ok(result);
        }
    }
}
     