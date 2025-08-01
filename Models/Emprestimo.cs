using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioRestApi.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataRetirada { get; set; }

        [Required]
        public DateTime DataDevolucao { get; set; }

        [Required]
        public bool Entregue { get; set; }

        [Required]
        public int LivroId { get; set; }

        [ForeignKey("LivroId")]
        public required Livro Livro { get; set; }
    }
}