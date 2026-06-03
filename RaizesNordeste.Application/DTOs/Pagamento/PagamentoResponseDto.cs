using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Application.DTOs.Pagamento;

public class PagamentoResponseDto
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public decimal Valor { get; set; }

    public StatusPagamentoEnum Status { get; set; }

    public string TransacaoMock { get; set; } = string.Empty;

    public DateTime? DataPagamento { get; set; }
}