using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.DTOs.Pagamento;
using RaizesNordeste.Application.Interfaces;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PagamentosController : ControllerBase
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentosController(
        IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    [HttpPost]
    public async Task<IActionResult> Processar(
        PagamentoCreateDto dto)
    {
        var resultado =
            await _pagamentoService
                .ProcessarPagamentoAsync(dto);

        return Ok(resultado);
    }
}