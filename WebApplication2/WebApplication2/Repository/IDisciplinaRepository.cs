using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IDisciplinaRepository
    {
        void CalificarParticipante(int idCompetencia, int idDisciplina, int idParticipante, float calificacion, string descripcion);
        List<Resultado> GetResultados(int idCompetencia, int idDisciplina);
    }
}
