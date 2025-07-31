using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;

namespace LaboratorioRestApi.Services
{
    public class BibliotecaService
    {
        private readonly IAutorRepository autorRepository;

        public BibliotecaService(IAutorRepository autorRepository)
        {
            this.autorRepository = autorRepository;
        }

        public IEnumerable<Autor> BuscarAutoresPorSobrenome(string sobrenome)
        {
            return autorRepository.BuscarPorUltimoNome(sobrenome);
        }

        public Autor? BuscarAutorPorId(int id)
        {
            return autorRepository.BuscarPorId(id);
        }

        public void AdicionarAutor(Autor autor)
        {
            autorRepository.Adicionar(autor);
            autorRepository.Salvar();
        }

        public void AtualizarAutor(Autor autor)
        {
            autorRepository.Atualizar(autor);
            autorRepository.Salvar();
        }
    }
}
