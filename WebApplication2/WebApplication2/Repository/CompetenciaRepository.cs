using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CompetenciaRepository : ICompetenciaRepository
    {
        private readonly List<Competencia> _competencias = new();
        private int _currentId = 1;

        public void Add(Competencia competencia)
        {
            competencia.IdCompetencia = _currentId++;
            _competencias.Add(competencia);
        }

        public Competencia Get(int idCompetencia)
        {
            return _competencias.FirstOrDefault(c => c.IdCompetencia == idCompetencia);
        }

        public void AddDisciplina(int idCompetencia, Disciplina disciplina)
        {
            var competencia = Get(idCompetencia);
            if (competencia != null)
            {
                competencia.Disciplinas.Add(disciplina);
            }
        }

        public void AddParticipante(int idCompetencia, Participante participante)
        {
            var competencia = Get(idCompetencia);
            if (competencia != null)
            {
                competencia.Participantes.Add(participante);
            }
        }

        public List<Disciplina> GetDisciplinas(int idCompetencia)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Disciplinas;
        }

        public List<Participante> GetParticipantes(int idCompetencia)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Participantes;
        }

        public Disciplina GetDisciplina(int idCompetencia, int idDisciplina)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Disciplinas.FirstOrDefault(d => d.IdDisciplina == idDisciplina);
        }

        public Participante GetParticipante(int idCompetencia, int idParticipante)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Participantes.FirstOrDefault(p => p.IdParticipante == idParticipante);
        }
    }
}

