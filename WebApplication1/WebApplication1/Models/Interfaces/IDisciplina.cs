using System;

namespace WebApplication1.Models
{
    public interface IDisciplina
    {
        int IdDisciplina { get; set; }
        string Nombre { get; set; }
        DateTime FechaCompeticion { get; set; }
        string Reglas { get; set; }
        string Categoria { get; set; }
        string Genero { get; set; }
        List<Resultado> Resultados { get; set; }

        void Accept(ICalificacionVisitor visitor, CalificacionRequest request);
    }
}