namespace WebApplication1.Models
{
    public class Competencia
    {
        public Competencia()
        {
            Disciplinas = new List<Disciplina>();
            Participantes = new List<Participante>();
        }

        public int IdCompetencia { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaComienzo { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Participante> Participantes { get; set; }
    }
}
