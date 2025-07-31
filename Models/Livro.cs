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

        // Chave estrangeira (FK)
        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        // Propriedade de navegação
        public Autor? Autor { get; set; }
    }
}
