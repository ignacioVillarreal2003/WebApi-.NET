using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public abstract class Disciplina : IDisciplina
    {
        [JsonConstructor]
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

        public virtual void Accept(ICalificacionVisitor visitor, CalificacionRequest request)
        {

        }
    }
}
