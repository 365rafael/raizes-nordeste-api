using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.Services;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequestDto dto)
    {
        await _authService.RegisterAsync(dto);

        return Ok("Usuário cadastrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequestDto dto)
    {
        var result = await _authService.LoginAsync(dto);

        return Ok(result);
    }
}