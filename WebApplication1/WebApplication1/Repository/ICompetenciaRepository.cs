using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ICompetenciaRepository
    {
        Competencia Add(Competencia competencia);
        Competencia Get(int idCompetencia);
        Disciplina AddDisciplina(int idCompetencia, Disciplina disciplina);
        Participante AddParticipante(int idCompetencia, Participante participante);
        List<Disciplina> GetDisciplinas(int idCompetencia);
        List<Participante> GetParticipantes(int idCompetencia);
        Disciplina GetDisciplina(int idCompetencia, int idDisciplina);
        Participante GetParticipante(int idCompetencia, int idParticipante);
    }
}
