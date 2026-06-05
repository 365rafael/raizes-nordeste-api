using RaizesNordeste.Application.DTOs.Pedido;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public PedidoService(
        IPedidoRepository pedidoRepository,
        IProdutoRepository produtoRepository,
        IEstoqueRepository estoqueRepository,
        IUsuarioRepository usuarioRepository)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;
        _estoqueRepository = estoqueRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<PedidoResponseDto>> ObterTodosAsync()
    {
        var pedidos = await _pedidoRepository.ObterTodosAsync();

        return pedidos.Select(x => new PedidoResponseDto
        {
            Id = x.Id,
            Cliente = x.Cliente.Nome,
            Unidade = x.Unidade.Nome,
            Total = x.Total,
            Status = x.Status,
            DataCriacao = x.DataCriacao
        }).ToList();
    }

    public async Task<int> CriarAsync(PedidoCreateDto dto)
    {
        var pedido = new Pedido
        {
            ClienteId = dto.ClienteId,
            UnidadeId = dto.UnidadeId,
            CanalPedido = dto.CanalPedido,
            Status = StatusPedidoEnum.AGUARDANDO_PAGAMENTO
        };

        var cliente =
        await _usuarioRepository.ObterPorIdAsync(dto.ClienteId);

        if (cliente == null)
            throw new Exception("Cliente não encontrado.");

        decimal total = 0;

        foreach (var itemDto in dto.Itens)
        {
            var produto =
                await _produtoRepository
                    .ObterPorIdAsync(itemDto.ProdutoId);

            if (produto == null)
                throw new Exception(
                    $"Produto {itemDto.ProdutoId} não encontrado.");

            var estoque =
                await _estoqueRepository
                    .ObterPorProdutoUnidadeAsync(
                        produto.Id,
                        dto.UnidadeId);

            if (estoque == null)
                throw new Exception(
                    $"Produto {produto.Nome} sem estoque.");

            if (estoque.Quantidade < itemDto.Quantidade)
                throw new Exception(
                    $"Estoque insuficiente para {produto.Nome}.");

            estoque.Quantidade -= itemDto.Quantidade;

            _estoqueRepository.Atualizar(estoque);

            pedido.Itens.Add(new ItemPedido
            {
                ProdutoId = produto.Id,
                Quantidade = itemDto.Quantidade,
                PrecoUnitario = produto.Preco
            });

            total += produto.Preco * itemDto.Quantidade;
        }

        pedido.Total = total;

        await _pedidoRepository.AdicionarAsync(pedido);

        await _pedidoRepository.SaveChangesAsync();
        await _estoqueRepository.SaveChangesAsync();

        return pedido.Id;
    }
}