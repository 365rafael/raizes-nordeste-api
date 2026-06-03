using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.DTOs.Pedido;
using RaizesNordeste.Application.Interfaces;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(
        IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(
            await _pedidoService.ObterTodosAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        PedidoCreateDto dto)
    {
        var id =
            await _pedidoService.CriarAsync(dto);

        return Ok(new
        {
            PedidoId = id
        });
    }
}