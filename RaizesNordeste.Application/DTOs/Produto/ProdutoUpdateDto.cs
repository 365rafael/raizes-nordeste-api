using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.DTOs.Produto;

public class ProdutoUpdateDto
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Descricao { get; set; }

    [Range(0.01, 999999.99,
        ErrorMessage = "Preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    public bool Ativo { get; set; }
}