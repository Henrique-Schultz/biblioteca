using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        void Adicionar(Livro livro);
        List<Livro> ListarTodos();
        List<Livro> ListarPorAutor(int autorId);
        Livro? ObterPorId(int id);
        void Salvar();
    }
}
