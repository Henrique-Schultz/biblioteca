using LaboratorioRestApi.Models;

namespace LaboratorioRestApi.Repositories
{
    public interface IAutorRepository
    {
        List<Autor> BuscarPorUltimoNome(string ultimoNome);
        Autor? BuscarPorId(int id);
        void Adicionar(Autor autor);
        void Atualizar(Autor autor);
        void Salvar();
    }
}
