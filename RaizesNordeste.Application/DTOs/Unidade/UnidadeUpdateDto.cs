using System.ComponentModel.DataAnnotations;

namespace RaizesNordeste.Application.DTOs.Unidade;

public class UnidadeUpdateDto
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [StringLength(200)]
    public string Cidade { get; set; } = string.Empty;
    [Required]
    [StringLength(30)]
    public string Estado { get; set; } = string.Empty;
}