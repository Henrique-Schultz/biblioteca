using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;
using LaboratorioRestApi.Repositories.Interfaces;

namespace LaboratorioRestApi.Services
{
    public class BibliotecaService
    {
        private readonly IAutorRepository autorRepository;
        private readonly ILivroRepository livroRepository;

        public BibliotecaService(IAutorRepository autorRepository, ILivroRepository livroRepository)
        {
            this.autorRepository = autorRepository;
            this.livroRepository = livroRepository;
        }

        // ---------- AUTOR ----------
        public List<Autor> BuscarAutoresPorSobrenome(string sobrenome)
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

        // ---------- LIVRO ----------
        public void AdicionarLivro(Livro livro)
        {
            livroRepository.Adicionar(livro);
            livroRepository.Salvar();
        }

        public List<Livro> BuscarTodosLivros()
        {
            return livroRepository.ListarTodos();
        }

        public List<Livro> BuscarLivrosPorAutor(int autorId)
        {
            return livroRepository.ListarPorAutor(autorId);
        }

        public Livro? BuscarLivroPorId(int id)
        {
            return livroRepository.ObterPorId(id);
        }
    }
}
