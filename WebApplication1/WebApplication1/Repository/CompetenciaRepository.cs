using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CompetenciaRepository : ICompetenciaRepository
    {
        private readonly List<Competencia> _competencias = new();
        private int _IdCompetencia = 1;
        private int _IdDisciplina = 1;
        private int _IdParticipante = 1;

        public Competencia Add(Competencia competencia)
        {
            competencia.IdCompetencia = _IdCompetencia++;
            _competencias.Add(competencia);
            return competencia;
        }

        public Competencia Get(int idCompetencia)
        {
            return _competencias.FirstOrDefault(c => c.IdCompetencia == idCompetencia);
        }

        public Disciplina AddDisciplina(int idCompetencia, Disciplina disciplina)
        {
            disciplina.IdDisciplina = _IdDisciplina++;
            var competencia = Get(idCompetencia);
            if (competencia != null)
            {
                competencia.Disciplinas.Add(disciplina);
                return disciplina;
            }
            return null;
        }

        public Participante AddParticipante(int idDisciplina, Participante participante)
        {
            participante.IdParticipante = _IdParticipante++;
            var disciplina = _competencias.SelectMany(c => c.Disciplinas).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            if (disciplina != null)
            {
                disciplina.Participantes.Add(participante);
                return participante;
            }
            return null;
        }

        public List<Disciplina> GetDisciplinas(int idCompetencia)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Disciplinas;
        }

        public List<Participante> GetParticipantes(int idDisciplina)
        {
            var disciplina = _competencias.SelectMany(c => c.Disciplinas).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            return disciplina?.Participantes;
        }

        public Disciplina GetDisciplina(int idCompetencia, int idDisciplina)
        {
            var competencia = Get(idCompetencia);
            return competencia?.Disciplinas.FirstOrDefault(d => d.IdDisciplina == idDisciplina);
        }

        public Participante GetParticipante(int idDisciplina, int idParticipante)
        {
            var disciplina = _competencias.SelectMany(c => c.Disciplinas).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            return disciplina?.Participantes.FirstOrDefault(p => p.IdParticipante == idParticipante);
        }
    }
}
}

