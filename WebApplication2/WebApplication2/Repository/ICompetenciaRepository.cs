using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface ICompetenciaRepository
    {
        void Add(Competencia competencia);
        Competencia Get(int idCompetencia);
        void AddDisciplina(int idCompetencia, Disciplina disciplina);
        void AddParticipante(int idCompetencia, Participante participante);
        List<Disciplina> GetDisciplinas(int idCompetencia);
        List<Participante> GetParticipantes(int idCompetencia);
        Disciplina GetDisciplina(int idCompetencia, int idDisciplina);
        Participante GetParticipante(int idCompetencia, int idParticipante);
    }
}
