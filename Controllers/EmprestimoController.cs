using LaboratorioRestApi.Models;
using LaboratorioRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly BibliotecaService _service;

        public EmprestimosController(BibliotecaService service)
        {
            _service = service;
        }

        [HttpPost("emprestar/{livroId}")]
        public ActionResult EmprestarLivro(int livroId)
        {
            try
            {
                _service.EmprestarLivro(livroId);
                return Ok("Livro emprestado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("devolver/{livroId}")]
        public ActionResult<double> DevolverLivro(int livroId)
        {
            try
            {
                double multa = _service.DevolverLivro(livroId);
                return Ok(multa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("historico/{livroId}")]
        public ActionResult<List<Emprestimo>> Historico(int livroId)
        {
            return Ok(_service.BuscarHistoricoEmprestimosDoLivro(livroId));
        }
    }
}
