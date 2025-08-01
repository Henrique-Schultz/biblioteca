using LaboratorioRestApi.Models;
using LaboratorioRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly BibliotecaService _service;

        public AutoresController(BibliotecaService service)
        {
            _service = service;
        }

        // GET: api/autores?sobrenome=Silva
        [HttpGet]
        public ActionResult<List<Autor>> GetAutoresPorSobrenome([FromQuery] string sobrenome)
        {
            var autores = _service.BuscarAutoresPorSobrenome(sobrenome);
            return Ok(autores);
        }

        // GET: api/autores/5
        [HttpGet("{id}")]
        public ActionResult<Autor> GetAutor(int id)
        {
            var autor = _service.BuscarAutorPorId(id);
            if (autor == null)
                return NotFound();

            return Ok(autor);
        }

        // POST: api/autores
        [HttpPost]
        public IActionResult PostAutor([FromBody] Autor autor)
        {
            _service.AdicionarAutor(autor);
            return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autor);
        }

        // PUT: api/autores/5
        [HttpPut("{id}")]
        public IActionResult PutAutor(int id, [FromBody] Autor autor)
        {
            if (id != autor.Id)
                return BadRequest("ID da URL não bate com o corpo da requisição.");

            var autorExistente = _service.BuscarAutorPorId(id);
            if (autorExistente == null)
                return NotFound();

            _service.AtualizarAutor(autor);
            return NoContent();
        }
    }
}