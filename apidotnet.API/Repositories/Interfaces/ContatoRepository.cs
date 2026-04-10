using apidotnet.Data;
using apidotnet.Domain.Entities;
using apidotnet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apidotnet.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contato> Criar(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<List<Contato>> Listar()
        {
            return await _context.Contatos
                .Where(c => c.Ativo)
                .ToListAsync();
        }

        public async Task<Contato> ObterPorId(int id)
        {
            return await _context.Contatos
                .FirstOrDefaultAsync(c => c.Id == id && c.Ativo);
        }
        
        public async Task<Contato> ObterPorIdSemFiltro(int id)
        {
            return await _context.Contatos
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Atualizar(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Contato contato)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}