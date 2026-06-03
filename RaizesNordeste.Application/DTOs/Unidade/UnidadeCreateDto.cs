using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.DTOs.Unidade;

public class UnidadeCreateDto
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cidade é obrigatório.")]
    [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
    public string Cidade { get; set; } = string.Empty;
    [Required]
    [StringLength(30, ErrorMessage = "O estado deve ter no máximo 30 caracteres.")]
    public string Estado { get; set; } = string.Empty;
}