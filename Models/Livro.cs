using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioRestApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Titulo { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int AutorId { get; set; }

        [ForeignKey("AutorId")]
        public required Autor Autor { get; set; }

        public required List<Emprestimo> Emprestimos { get; set; }
    }
}
