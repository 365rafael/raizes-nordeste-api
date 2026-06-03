using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.DTOs.Unidade;
using RaizesNordeste.Application.Interfaces;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UnidadesController : ControllerBase
{
    private readonly IUnidadeService _unidadeService;

    public UnidadesController(IUnidadeService unidadeService)
    {
        _unidadeService = unidadeService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        return Ok(await _unidadeService.ObterTodosAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var unidade = await _unidadeService.ObterPorIdAsync(id);

        if (unidade == null)
            return NotFound();

        return Ok(unidade);
    }

    [HttpPost]
    public async Task<IActionResult> Criar(UnidadeCreateDto dto)
    {
        var id = await _unidadeService.CriarAsync(dto);

        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, UnidadeUpdateDto dto)
    {
        await _unidadeService.AtualizarAsync(id, dto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _unidadeService.RemoverAsync(id);

        return NoContent();
    }
}