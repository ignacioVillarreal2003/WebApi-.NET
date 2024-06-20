using System;

namespace WebApplication1.Models
{
    public interface ICalificacionPeso
    {
        bool CalificarParticipante(int idParticipante, float peso);
    }
}