namespace WebApplication2.Models
{
    public abstract class Disciplina
    {
        public Disciplina()
        {
            Resultados = new List<Resultado>();
        }

        public int IdDisciplina { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCompeticion { get; set; }
        public string Reglas { get; set; }
        public string Categoria { get; set; }
        public string Genero { get; set; }
        public List<Resultado> Resultados { get; set; }

        public abstract bool CalificarParticipante(int idParticipante, string descripcion);
    }
}
