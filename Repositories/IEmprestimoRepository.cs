using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Adicionar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        List<Emprestimo> BuscarPorLivro(int livroId);
        Emprestimo? BuscarEmprestimoEmAbertoPorLivro(int livroId);
        Emprestimo? BuscarPorId(int id);
        void Salvar();
    }
}
