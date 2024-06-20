namespace WebApplication1.Models
{
    public class CalificacionVisitor : ICalificacionVisitor
    {
        public float Visit(Natacion natacion, CalificacionRequest request)
        {
            if (request.IdParticipante == null)
            {
                return natacion.CalificarParticipante(request.Tiempo);
            }
            return null;
        }

        public float Visit(Alterofilia alterofilia, CalificacionRequest request)
        {
            if (request.IdParticipante != null)
            {
                return alterofilia.CalificarParticipante(request.Peso);
            }
            return null;
        }
    }
}
