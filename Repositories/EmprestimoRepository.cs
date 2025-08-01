using LaboratorioRestApi.Data;
using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioRestApi.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _context;

        public EmprestimoRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
        }

        public List<Emprestimo> BuscarPorLivro(int livroId)
        {
            return _context.Emprestimos
                .Where(e => e.LivroId == livroId)
                .ToList();
        }

        public Emprestimo? BuscarEmprestimoEmAbertoPorLivro(int livroId)
        {
            return _context.Emprestimos
                .FirstOrDefault(e => e.LivroId == livroId && !e.Entregue);
        }

        public Emprestimo? BuscarPorId(int id)
        {
            return _context.Emprestimos.Find(id);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
