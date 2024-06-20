using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ICompetenciaRepository _competenciaRepository;

        public DisciplinaRepository(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public Resultado CalificarParticipante(int idCompetencia, int idDisciplina, int idParticipante, float calificacion, string descripcion)
        {
            var disciplina = _competenciaRepository.GetDisciplinas(idCompetencia).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            if (disciplina != null)
            {
                var resultado = new Resultado
                {
                    IdParticipante = idParticipante,
                    IdDisciplina = idDisciplina,
                    Calificacion = calificacion,
                    Descripcion = descripcion,
                    Fecha = DateTime.Now
                };
                disciplina.Resultados.Add(resultado);
                return resultado;
            }
            return null;
        }

        public List<Resultado> GetResultados(int idCompetencia, int idDisciplina)
        {
            var disciplina = _competenciaRepository.GetDisciplinas(idCompetencia).FirstOrDefault(d => d.IdDisciplina == idDisciplina);
            return disciplina?.Resultados;
        }

        //Actualizamos el repositorio para que pueda agregar disciplinas específicas como Natacion.
        public Disciplina AddDisciplina(int idCompetencia, Disciplina disciplina)
        {
            disciplina.IdDisciplina = _IdDisciplina++;
            var competencia = Get(idCompetencia);
            if (competencia != null)
            {
                if (disciplina is Natacion)
                {
                    var natacion = new Natacion();
                    competencia.Disciplinas.Add(natacion);
                    return natacion;
                }
                else
                {
                    competencia.Disciplinas.Add(disciplina);
                    return disciplina;
                }
            }
            return null;
        }
    }
}
