using api.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase {
    private readonly ITokenService _tokenService;

    public AuthenticateController(ITokenService tokenService) {
        this._tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpGet("generate")]
    public ActionResult<string> GenerateToken() {
        return Ok(this._tokenService.CreateToken());
    }
}
