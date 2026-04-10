using Microsoft.EntityFrameworkCore;
using apidotnet.Domain.Entities;

namespace apidotnet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }
    }
}