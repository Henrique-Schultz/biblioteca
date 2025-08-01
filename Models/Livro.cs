using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioRestApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int AutorId { get; set; }

        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }

        public List<Emprestimo> Emprestimos { get; set; }
    }
}
