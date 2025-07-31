using System.ComponentModel.DataAnnotations;

namespace LaboratorioRestApi.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string PrimeiroNome { get; set; }

        [Required]
        public required string UltimoNome { get; set; }

        // Propriedade de navegação (1 autor → muitos livros)
        public ICollection<Livro> Livros { get; set; } = [];
    }
}