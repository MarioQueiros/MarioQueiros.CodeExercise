using MarioQueiros.CodeExercise.Properties;

namespace MarioQueiros.CodeExercise.Service
{
    // This class is not to be modified
    public class ReportProvider
    {
        // Mimics a call to a web service that returns serialised report data.
        public static string GetReportData()
        {
            return Settings.Default.ReportData;
        }
    }
}