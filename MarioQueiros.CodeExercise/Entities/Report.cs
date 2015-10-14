using System;

namespace MarioQueiros.CodeExercise.Entities
{
    // This class is not to be modified
    public class Report
    {
        public int Id { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public DateTime PriorPeriodStart { get; set; }

        public DateTime PriorPeriodEnd { get; set; }

        public int PeriodTotal { get; set; }

        public int PriorPeriodTotal { get; set; }

        public string ReasonForPeriodDecrease { get; set; }
    }
}