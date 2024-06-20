namespace WebApplication1.Models
{
    public class Natacion : Disciplina, ICalificacionTiempo
    {
        public override float Accept(ICalificacionVisitor visitor, CalificacionRequest request)
        {
            return visitor.Visit(this, request);
        }

        public float CalificarParticipante(float tiempo)
        {
            float calificacion = tiempo * 10;
            if (calificacion < 0)
            {
                calificacion = 0;
            }
            return calificacion;

        }
    }
}
