using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("disciplina")]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICompetenciaRepository _competenciaRepository;
        private readonly ICalificacionVisitor _calificacionVisitor;

        public DisciplinasController(IDisciplinaRepository disciplinaRepository, ICompetenciaRepository competenciaRepository, ICalificacionVisitor calificacionVisitor)
        {
            _disciplinaRepository = disciplinaRepository;
            _competenciaRepository = competenciaRepository;
            _calificacionVisitor = calificacionVisitor;
        }

        [HttpPost("{idCompetencia}/{idDisciplina}")]
        public IActionResult CalificarParticipante(int idCompetencia, int idDisciplina, [FromBody] CalificacionRequest request)
        {
            var disciplina = _competenciaRepository.GetDisciplina(idCompetencia, idDisciplina);
            if (disciplina == null)
            {
                return NotFound();
            }
            var calificacion = disciplina.Accept(_calificacionVisitor, request);
            if (calificacion == null)
            {
                var cal = _disciplinaRepository.CalificarParticipante(idCompetencia, idDisciplina, request.IdParticipante, calificacion, request.Descripcion);
                return Ok(cal);
            }
            return NotFound();
        }


        [HttpGet("{idCompetencia}/{idDisciplina}")]
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