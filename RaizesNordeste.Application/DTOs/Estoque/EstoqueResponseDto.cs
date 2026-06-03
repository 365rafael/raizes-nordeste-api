namespace RaizesNordeste.Application.DTOs.Estoque;

public class EstoqueResponseDto
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public string Produto { get; set; } = string.Empty;

    public int UnidadeId { get; set; }

    public string Unidade { get; set; } = string.Empty;

    public int Quantidade { get; set; }
}