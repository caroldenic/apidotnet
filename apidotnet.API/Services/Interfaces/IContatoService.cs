using apidotnet.DTOs;

namespace apidotnet.Services.Interfaces
{
    public interface IContatoService
    {
        Task<ContatoResponseDto> Criar(ContatoCreateDto dto);
        Task<List<ContatoResponseDto>> Listar();
        Task<ContatoResponseDto> Obter(int id);
        Task Desativar(int id);
        Task Ativar(int id);
        Task Excluir(int id);
    }
}