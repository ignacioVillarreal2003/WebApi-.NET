using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("disciplina")]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinasController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpPost("{idCompetencia}/{idDisciplina}/calificar")]
        public IActionResult CalificarParticipante(int idCompetencia, int idDisciplina, [FromBody] Resultado request)
        {
            _disciplinaRepository.CalificarParticipante(idCompetencia, idDisciplina, request.IdParticipante, request.Calificacion, request.Descripcion);
            return Ok();
        }

        [HttpGet("{idCompetencia}/{idDisciplina}/resultados")]
        public IActionResult ObtenerResultados(int idCompetencia, int idDisciplina)
        {
            var resultados = _disciplinaRepository.GetResultados(idCompetencia, idDisciplina);
            if (resultados == null)
            {
                return NotFound();
            }
            return Ok(resultados);
        }
    }
}
