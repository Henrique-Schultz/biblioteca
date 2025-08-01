using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _context;

        public LivroRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Livro livro)
        {
            _context.Livros.Add(livro);
        }

        public List<Livro> ListarTodos()
        {
            return _context.Livros.Include(l => l.Autor).ToList();
        }

        public List<Livro> ListarPorAutor(int autorId)
        {
            return _context.Livros.Include(l => l.Autor)
                                  .Where(l => l.AutorId == autorId)
                                  .ToList();
        }

        public Livro? ObterPorId(int id)
        {
            return _context.Livros.Include(l => l.Autor).FirstOrDefault(l => l.Id == id);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
