using System;
using System.Collections.Generic;
using System.Linq;
using MarioQueiros.CodeExercise.Entities;
using MarioQueiros.CodeExercise.Persistence;
using MarioQueiros.CodeExercise.Service;

namespace MarioQueiros.CodeExercise
{
    public class Program
    {
        private static readonly IReportRepository _reportRepository = new ReportRepository();
        private static readonly ISerializer _serializer = new Serializer();

        // Entry point to the application.
        public static void Main()
        {
            SetReports();
            DisplayPeriodSum();

            Console.Read();
        }

        // Displays the sum of reports for a given period.
        private static void DisplayPeriodSum()
        {
            var sum = _reportRepository.Sum( new DateTime( 2012, 01, 01 ), DateTime.Now );
            Console.WriteLine( "Sum for period is: " + sum );
        }

        // Gets a collection of reports and passes them to the repository.
        private static void SetReports()
        {
            var reports = GetReports().ToList();
            for ( var i = 0; i < reports.Count(); i++ )
            {
                try
                {
                    SetReport( reports[ i ] );
                }
                catch ( Exception ex )
                {
                    Console.WriteLine( $"ERROR: Report Id {reports[ i ].Id} - {ex.Message}" );
                }
            }
        }

        /* Saves a report to the repository
         * This method should be modified to perform validation on the report.
         * This method should also output a message to denote whether the report was saved, or whether there were any validation failures.
         */
        private static void SetReport( Report report )
        {
            _reportRepository.Set( report );
            Console.WriteLine( "Saved report with ID: " + report.Id );
        }

        // Gets serialised report data, passes the data for deserialisation, and returns a collection of reports.
        private static IEnumerable<Report> GetReports()
        {
            var reportData = ReportProvider.GetReportData();
            return _serializer.Deserialize<IEnumerable<Report>>( reportData );
        }
    }
}