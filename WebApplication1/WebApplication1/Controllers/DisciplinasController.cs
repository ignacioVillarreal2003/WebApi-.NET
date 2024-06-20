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

        public DisciplinasController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        /*
        [HttpPost("{idCompetencia}/{idDisciplina}")]
        public IActionResult CalificarParticipante(int idCompetencia, int idDisciplina, [FromBody] Resultado request)
        {
            var resultados = _disciplinaRepository.CalificarParticipante(idCompetencia, idDisciplina, request.IdParticipante, request.Calificacion, request.Descripcion);
            if (resultados == null)
            {
                return NotFound();
            }
            return Ok(resultados);
        }
        */

        //Actualizar los métodos de calificación para asegurarnos de que la nueva disciplina 
        //específica pueda ser calificada correctamente.
        [HttpPost("{idCompetencia}/{idDisciplina}")]
        public IActionResult CalificarParticipante(int idCompetencia, int idDisciplina, [FromBody] Resultado request)
        {
            var disciplina = _competenciaRepository.GetDisciplina(idCompetencia, idDisciplina);
            if (disciplina is Natacion natacion)
            {
                var resultado = natacion.CalificarParticipante(request.IdParticipante, request.Descripcion);
                if (resultado)
                {
                    return Ok(natacion.Resultados.FirstOrDefault(r => r.IdParticipante == request.IdParticipante));
                }
            }
            else
            {
                var resultado = _disciplinaRepository.CalificarParticipante(idCompetencia, idDisciplina, request.IdParticipante, request.Calificacion, request.Descripcion);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
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