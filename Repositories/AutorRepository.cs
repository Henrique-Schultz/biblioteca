using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaDbContext _context;

        public AutorRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Autor> BuscarPorUltimoNome(string ultimoNome)
        {
            return _context.Autores
                .Where(a => a.UltimoNome.ToLower() == ultimoNome.ToLower())
                .ToList();
        }

        public Autor? BuscarPorId(int id)
        {
            return _context.Autores.Find(id);
        }

        public void Adicionar(Autor autor)
        {
            _context.Autores.Add(autor);
        }

        public void Atualizar(Autor autor)
        {
            _context.Autores.Update(autor);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
