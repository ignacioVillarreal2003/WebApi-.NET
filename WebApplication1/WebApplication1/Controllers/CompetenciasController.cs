using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("competencia")]
    public class CompetenciasController : ControllerBase
    {
        private readonly ICompetenciaRepository _competenciaRepository;

        public CompetenciasController(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        [HttpPost]
        public IActionResult CrearCompetencia([FromBody] Competencia competencia)
        {
            Competencia comp = _competenciaRepository.Add(competencia);
            return Ok(comp);
        }

        [HttpGet("{idCompetencia}")]
        public IActionResult ObtenerCompetencia(int idCompetencia)
        {
            var competencia = _competenciaRepository.Get(idCompetencia);
            if (competencia == null)
            {
                return NotFound();
            }
            return Ok(competencia);
        }

        [HttpPost("{idCompetencia}/disciplinas")]
        public IActionResult RegistrarDisciplina(int idCompetencia, [FromBody] Disciplina disciplina)
        {
            Disciplina disc = _competenciaRepository.AddDisciplina(idCompetencia, disciplina);
            return Ok(disc);
        }

        [HttpGet("{idCompetencia}/disciplinas")]
        public IActionResult ObtenerDisciplinas(int idCompetencia)
        {
            var disciplina = _competenciaRepository.GetDisciplinas(idCompetencia);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }

        [HttpGet("{idCompetencia}/disciplinas/{idDisciplina}")]
        public IActionResult ObtenerDisciplina(int idCompetencia, int idDisciplina)
        {
            var disciplina = _competenciaRepository.GetDisciplina(idCompetencia, idDisciplina);
            if (disciplina == null)
            {
                return NotFound();
            }
            return Ok(disciplina);
        }

        [HttpPost("{idDisciplina}/participantes")]
        public IActionResult RegistrarParticipante(int idDisciplina, [FromBody] Participante participante)
        {
            Participante part = _competenciaRepository.AddParticipante(idDisciplina, participante);
            return Ok(part);
        }

        [HttpGet("{idDisciplina}/participantes")]
        public IActionResult ObtenerParticipantes(int idDisciplina)
        {
            var participante = _competenciaRepository.GetParticipantes(idDisciplina);
            if (participante == null)
            {
                return NotFound();
            }
            return Ok(participante);
        }

        [HttpGet("{idDisciplina}/participantes/{idParticipante}")]
        public IActionResult ObtenerParticipante(int idDisciplina, int idParticipante)
        {
            var participante = _competenciaRepository.GetParticipante(idDisciplina, idParticipante);
            if (participante == null)
            {
                return NotFound();
            }
            return Ok(participante);
        }
    }
}
