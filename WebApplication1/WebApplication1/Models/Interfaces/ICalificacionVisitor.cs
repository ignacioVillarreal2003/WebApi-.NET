using System;

namespace WebApplication1.Models
{
    public interface ICalificacionVisitor
    {
        void Visit(Natacion natacion, CalificacionRequest request);
        void Visit(Alterofilia alterofilia, CalificacionRequest request);
    }
}