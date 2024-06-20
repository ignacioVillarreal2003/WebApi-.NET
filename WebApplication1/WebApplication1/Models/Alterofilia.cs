namespace WebApplication1.Models
{
    public class Alterofilia : Disciplina, ICalificacionPeso
    {
        public override float Accept(ICalificacionVisitor visitor, CalificacionRequest request)
        {
            return visitor.Visit(this, request);
        }

        public float CalificarParticipante(float peso)
        {
            float calificacion = peso * 1.23;
            if (calificacion < 0)
            {
                calificacion = 0;
            }
            return calificacion;
        }
    }
}
