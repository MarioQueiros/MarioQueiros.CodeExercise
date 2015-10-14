using System;
using MarioQueiros.CodeExercise.Entities;

namespace MarioQueiros.CodeExercise.Persistence
{
    public interface IReportRepository
    {
        void Set( Report report );

        int Sum( DateTime from, DateTime to );
    }
}