using LaboratorioRestApi.Models;
using LaboratorioRestApi.Repositories;
using LaboratorioRestApi.Repositories.Interfaces;

namespace LaboratorioRestApi.Services
{
    public class BibliotecaService
    {
        private readonly IAutorRepository autorRepository;
        private readonly ILivroRepository livroRepository;
        private readonly IEmprestimoRepository emprestimoRepository;

        public BibliotecaService(
            IAutorRepository autorRepository,
            ILivroRepository livroRepository,
            IEmprestimoRepository emprestimoRepository)
        {
            this.autorRepository = autorRepository;
            this.livroRepository = livroRepository;
            this.emprestimoRepository = emprestimoRepository;
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

        // ---------- EMPRÉSTIMO ----------
        public void EmprestarLivro(int livroId)
        {
            var livro = livroRepository.ObterPorId(livroId);
            if (livro == null) throw new Exception("Livro não encontrado.");

            var emprestimoAberto = emprestimoRepository.BuscarEmprestimoEmAbertoPorLivro(livroId);
            if (emprestimoAberto != null) throw new Exception("Livro já emprestado.");

            var novoEmprestimo = new Emprestimo
            {
                LivroId = livroId,
                Livro = livro,
                DataRetirada = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(7),
                Entregue = false
            };

            emprestimoRepository.Adicionar(novoEmprestimo);
            emprestimoRepository.Salvar();
        }

        public double DevolverLivro(int livroId)
        {
            var emprestimo = emprestimoRepository.BuscarEmprestimoEmAbertoPorLivro(livroId);
            if (emprestimo == null) throw new Exception("Nenhum empréstimo em aberto para este livro.");

            emprestimo.Entregue = true;
            var hoje = DateTime.Now;

            double multa = 0;
            if (hoje > emprestimo.DataDevolucao)
            {
                var diasAtraso = (hoje - emprestimo.DataDevolucao).Days;
                multa = diasAtraso * 2.0; // multa de R$2 por dia
            }

            emprestimoRepository.Atualizar(emprestimo);
            emprestimoRepository.Salvar();

            return multa;
        }

        public List<Emprestimo> BuscarHistoricoEmprestimosDoLivro(int livroId)
        {
            return emprestimoRepository.BuscarPorLivro(livroId);
        }
    }
}
