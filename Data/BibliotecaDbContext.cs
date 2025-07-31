using LaboratorioRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        // public DbSet<Emprestimo> Emprestimos { get; set; } ← depois a gente adiciona

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui você pode configurar relações, seeds, constraints se quiser
        }
    }
}
