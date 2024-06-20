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
        private readonly ICalificacionVisitor _calificacionVisitor;

        public CompetenciasController(ICompetenciaRepository competenciaRepository, ICalificacionVisitor calificacionVisitor)
        {
            _competenciaRepository = competenciaRepository;
            _calificacionVisitor = calificacionVisitor;
        }

        [HttpPost("{idCompetencia}/disciplinas")]
        public IActionResult RegistrarDisciplina(int idCompetencia, [FromBody] DisciplinaRequest request)
        {
            Disciplina nuevaDisciplina = CrearDisciplina(request);
            var disc = _competenciaRepository.AddDisciplina(idCompetencia, nuevaDisciplina);
            return Ok(disc);
        }

        private Disciplina CrearDisciplina(DisciplinaRequest request)
        {
            if (request.TipoDisciplina == "Natacion")
            {
                return new Natacion
                {
                    Nombre = request.Nombre,
                    FechaCompeticion = request.FechaCompeticion,
                    Reglas = request.Reglas,
                    Categoria = request.Categoria,
                    Genero = request.Genero
                };
            }
            else if (request.TipoDisciplina == "Alterofilia")
            {
                return new Alterofilia
                {
                    Nombre = request.Nombre,
                    FechaCompeticion = request.FechaCompeticion,
                    Reglas = request.Reglas,
                    Categoria = request.Categoria,
                    Genero = request.Genero
                };
            }
            else
            {
                throw new ArgumentException($"Disciplina desconocida: {request.TipoDisciplina}");
            }
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
