using apidotnet.Domain.Entities;

namespace apidotnet.Repositories.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> Criar(Contato contato);
        Task<List<Contato>> Listar();
        Task<Contato> ObterPorId(int id);
        Task<Contato> ObterPorIdSemFiltro(int id);
        Task Atualizar(Contato contato);
        Task Remover(Contato contato);
    }
}