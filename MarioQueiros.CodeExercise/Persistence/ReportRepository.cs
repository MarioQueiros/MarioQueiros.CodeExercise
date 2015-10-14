using System;
using System.Collections.Generic;
using System.Linq;
using MarioQueiros.CodeExercise.Entities;

namespace MarioQueiros.CodeExercise.Persistence
{
    public class ReportRepository : IReportRepository
    {
        private readonly IList<Report> _reports;

        public ReportRepository()
        {
            _reports = new List<Report>();
        }

        public void Set( Report report )
        {
            if ( report == null )
                throw new ArgumentNullException( "Report null" );

            if ( report.PeriodEnd < report.PeriodStart )
                throw new Exception( "End period lower than start period" );

            if ( report.PriorPeriodEnd < report.PeriodStart )
                throw new Exception( "Prior end period lower than start period" );

            if ( report.PriorPeriodEnd < report.PriorPeriodStart )
                throw new Exception( "Prior end period lower than prior start period" );

            if ( report.PeriodTotal <= 0 )
                throw new Exception( "Period total is equal or lower than zero" );

            if ( report.PriorPeriodTotal <= 0 )
                throw new Exception( "Period total is equal or lower than zero" );

            if ( report.PriorPeriodTotal > report.PeriodTotal && string.IsNullOrEmpty( report.ReasonForPeriodDecrease ) )
                throw new Exception( "Reason is mandatory when prior period total is greater than period total" );

            _reports.Add( report );
        }

        public int Sum( DateTime @from, DateTime to )
        {
            if ( to < from )
                throw new Exception( "To date is lower than from date" );

            var sum = 0;

            _reports.ToList().ForEach( r =>
             {
                 if ( @from <= r.PeriodStart && @from <= r.PriorPeriodStart && to >= r.PeriodEnd && to >= r.PriorPeriodEnd )
                     sum += r.PeriodTotal - r.PriorPeriodTotal;
             } );

            return sum;
        }
    }
}