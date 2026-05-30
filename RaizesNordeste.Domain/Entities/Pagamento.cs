using RaizesNordeste.Domain.Enums;

namespace RaizesNordeste.Domain.Entities;

public class Pagamento
{
    public int Id { get; set; }

    public int PedidoId { get; set; }

    public Pedido Pedido { get; set; } = null!;

    public decimal Valor { get; set; }

    public StatusPagamentoEnum Status { get; set; }

    public DateTime? DataPagamento { get; set; }

    public string TransacaoMock { get; set; } = string.Empty;
}