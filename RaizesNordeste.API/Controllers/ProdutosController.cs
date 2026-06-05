using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesNordeste.Application.DTOs.Produto;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var produtos = await _produtoService.ObterTodosAsync();

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);

        if (produto == null)
            return NotFound("Produto não encontrado.");

        return Ok(produto);
    }

    [Authorize(Roles = "ADMIN")]
    [HttpPost]
    public async Task<IActionResult> Criar(
        ProdutoCreateDto dto)
    {
        var id = await _produtoService.CriarAsync(dto);

        return CreatedAtAction(
            nameof(ObterPorId),
            new { id },
            new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        int id,
        ProdutoUpdateDto dto)
    {
        await _produtoService.AtualizarAsync(id, dto);

        return NoContent();
    }

    [Authorize(Roles = "ADMIN")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        await _produtoService.RemoverAsync(id);

        return NoContent();
    }
}