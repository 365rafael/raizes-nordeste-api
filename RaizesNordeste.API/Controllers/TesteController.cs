using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/teste")]
public class TesteController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Mensagem = "JWT funcionando corretamente!"
        });
    }
}