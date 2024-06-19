using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IDisciplinaRepository
    {
        Resultado CalificarParticipante(int idCompetencia, int idDisciplina, int idParticipante, float calificacion, string descripcion);
        List<Resultado> GetResultados(int idCompetencia, int idDisciplina);
    }
}
