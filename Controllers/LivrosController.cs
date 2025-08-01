using LaboratorioRestApi.Models;
using LaboratorioRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   public class LivrosController : ControllerBase
    {
        private readonly BibliotecaService _service;

        public LivrosController(BibliotecaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Livro>> GetTodos()
        {
            return Ok(_service.BuscarTodosLivros());
        }

        [HttpGet("autor/{autorId}")]
        public ActionResult<List<Livro>> GetPorAutor(int autorId)
        {
            return Ok(_service.BuscarLivrosPorAutor(autorId));
        }

        [HttpGet("{id}")]
        public ActionResult<Livro> GetPorId(int id)
        {
            var livro = _service.BuscarLivroPorId(id);
            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Livro livro)
        {
            _service.AdicionarLivro(livro);
            return CreatedAtAction(nameof(GetPorId), new { id = livro.Id }, livro);
        }
    }

}
