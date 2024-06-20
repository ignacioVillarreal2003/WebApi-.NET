namespace WebApplication1.Models
{
    public class CalificacionRequest
    {
        public int IdParticipante { get; set; }
        public string Descripcion { get; set; }
        public float? Tiempo { get; set; }
        public float? Peso { get; set; }
    }
}
