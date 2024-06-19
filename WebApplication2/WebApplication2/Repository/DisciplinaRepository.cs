using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ICompetenciaRepository _competenciaRepository;

        public DisciplinaRepository(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public void CalificarParticipante(int idCompetencia, int idDisciplina, int idParticipante, float calificacion, string descripcion)
        {
            var disciplina = _competenciaRepository.GetDisciplinas(idCompetencia).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            if (disciplina != null)
            {
                var resultado = new Resultado
                {
                    IdParticipante = idParticipante,
                    Calificacion = calificacion,
                    Descripcion = descripcion,
                    Fecha = DateTime.Now
                };
                disciplina.Resultados.Add(resultado);
            }
        }

        public List<Resultado> GetResultados(int idCompetencia, int idDisciplina)
        {
            var disciplina = _competenciaRepository.GetDisciplinas(idCompetencia).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            return disciplina?.Resultados;
        }
    }
}
