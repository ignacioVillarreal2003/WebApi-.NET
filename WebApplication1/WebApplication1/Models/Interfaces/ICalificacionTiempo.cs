using System;

namespace WebApplication1.Models
{
    public interface ICalificacionTiempo
    {
        bool CalificarParticipante(int idParticipante, float tiempo);
    }
}