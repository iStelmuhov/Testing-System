using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.Unity;

namespace TestingSystem.TestApp
{
    class ModelReporter
    {
        public ModelReporter(TextWriter output)
        {
            this.output = output;
        }

        public void GenerateReport(TestSystemModel model)
        {
            ReportCollection("Accouts", model.Accouts);
            ReportCollection("Categories", model.Categories);
            ReportCollection("Questions", model.Questions);
            ReportCollection("Subjects", model.Subjects);
            ReportCollection("TestResults", model.TestResults);
            ReportCollection("TestSessions", model.TestSessions);
        }

        private void ReportCollection<T>(string title, ICollection<T> items)
        {
            output.WriteLine("==== {0} ==== ", title);
            output.WriteLine();

            foreach (var item in items)
            {
                output.WriteLine(item);
                output.WriteLine();
            }

            output.WriteLine();
        }

        private TextWriter output;
    }
}