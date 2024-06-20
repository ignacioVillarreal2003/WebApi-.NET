namespace WebApplication1.Models
{
    public class Natacion : Disciplina
    {
        public Natacion() : base()
        {
        }

        public override bool CalificarParticipante(int idParticipante, string descripcion)
        {
            // Implementar la lógica específica de puntuación para Natacion
            var participante = Resultados.FirstOrDefault(r => r.IdParticipante == idParticipante);
            if (participante != null)
            {
                // Supongamos que la puntuación para natación se basa en el tiempo registrado.
                // Cuanto menor sea el tiempo, mayor será la calificación.
                float tiempo = float.Parse(descripcion); // Convertir la descripción a un tiempo (en segundos, por ejemplo).
                float calificacion = 100 - tiempo; // Ejemplo simple de calificación.
                if (calificacion < 0) calificacion = 0; // Asegurar que la calificación no sea negativa.

                participante.Calificacion = calificacion;
                participante.Descripcion = descripcion;
                participante.Fecha = DateTime.Now;

                return true;
            }
            return false;
        }
    }
}
