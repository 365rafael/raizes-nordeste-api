using BCrypt.Net;
using RaizesNordeste.Application.Interfaces;
using RaizesNordeste.Domain.Entities;
using RaizesNordeste.Domain.Enums;
using RaizesNordeste.Domain.Interfaces;

namespace RaizesNordeste.Application.Services;

public class AuthService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        IUsuarioRepository usuarioRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _usuarioRepository = usuarioRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task RegisterAsync(RegisterRequestDto dto)
    {
        var usuarioExistente =
            await _usuarioRepository.ObterPorEmailAsync(dto.Email);

        if (usuarioExistente != null)
            throw new Exception("E-mail já cadastrado.");

        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Role = RoleEnum.CLIENTE
        };

        await _usuarioRepository.AdicionarAsync(usuario);
        await _usuarioRepository.SaveChangesAsync();
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
    {
        var usuario =
            await _usuarioRepository.ObterPorEmailAsync(dto.Email);

        if (usuario == null)
            throw new Exception("Usuário ou senha inválidos.");

        var senhaValida =
            BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

        if (!senhaValida)
            throw new Exception("Usuário ou senha inválidos.");

        var token = _jwtTokenGenerator.GenerateToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Expiracao = DateTime.UtcNow.AddHours(2)
        };
    }
}