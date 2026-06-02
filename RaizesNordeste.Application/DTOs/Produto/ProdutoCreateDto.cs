namespace RaizesNordeste.Application.DTOs.Produto;

public class ProdutoCreateDto
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}