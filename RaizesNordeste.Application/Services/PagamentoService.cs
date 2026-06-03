using RaizesNordeste.Application.DTOs.Pagamento;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public PagamentoService(
        IPagamentoRepository pagamentoRepository,
        IPedidoRepository pedidoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<PagamentoResponseDto> ProcessarPagamentoAsync(
        PagamentoCreateDto dto)
    {
        var pedido =
            await _pedidoRepository.ObterPorIdAsync(dto.PedidoId);

        if (pedido == null)
            throw new Exception("Pedido não encontrado.");

        if (pedido.Status != StatusPedidoEnum.AGUARDANDO_PAGAMENTO)
            throw new Exception("Pedido não está aguardando pagamento.");

        var pagamentoExistente =
            await _pagamentoRepository
                .ObterPorPedidoIdAsync(dto.PedidoId);

        if (pagamentoExistente != null)
            throw new Exception("Pagamento já registrado.");

        var pagamento = new Pagamento
        {
            PedidoId = pedido.Id,
            Valor = pedido.Total,
            Status = StatusPagamentoEnum.APROVADO,
            DataPagamento = DateTime.UtcNow,
            TransacaoMock =
                $"TRX-{Guid.NewGuid().ToString()[..8].ToUpper()}"
        };

        await _pagamentoRepository.AdicionarAsync(pagamento);

        pedido.Status = StatusPedidoEnum.PAGO;

        _pedidoRepository.Atualizar(pedido);

        await _pagamentoRepository.SaveChangesAsync();
        await _pedidoRepository.SaveChangesAsync();

        return new PagamentoResponseDto
        {
            Id = pagamento.Id,
            PedidoId = pagamento.PedidoId,
            Valor = pagamento.Valor,
            Status = pagamento.Status,
            DataPagamento = pagamento.DataPagamento,
            TransacaoMock = pagamento.TransacaoMock
        };
    }
}