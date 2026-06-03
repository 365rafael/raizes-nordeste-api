using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.DTOs.Estoque;
using RaizesNordeste.Application.Interfaces;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;

    public EstoqueController(
        IEstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(
            await _estoqueService.ObterTodosAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        EstoqueCreateDto dto)
    {
        var id =
            await _estoqueService.CriarAsync(dto);

        return Ok(id);
    }

    [HttpPost("{id}/entrada")]
    public async Task<IActionResult> Entrada(
        int id,
        EstoqueMovimentacaoDto dto)
    {
        await _estoqueService.EntradaAsync(
        id,
        dto.Quantidade);

        return Ok("Entrada realizada.");
    }

    [HttpPost("{id}/saida")]
    public async Task<IActionResult> Saida(
    int id,
    EstoqueMovimentacaoDto dto)
    {
        await _estoqueService.SaidaAsync(
        id,
        dto.Quantidade);

        return Ok("Saída realizada.");
    }
}