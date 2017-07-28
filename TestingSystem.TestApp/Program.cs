using System;
using System.IO;
using System.Text;
using TestingSystem.Repository.EntityFramework;

namespace TestingSystem.TestApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            TestSystemModel model1 = TestModelGenerator.GenerateTestData();
            using (var dbContext = new TestSystemDbContext(true))
            {
                ModelSaver saver = new ModelSaver(dbContext);
                saver.Save(model1);
            }

            using (var dbContext = new TestSystemDbContext(true))
            {
                ModelRestorer restorer = new ModelRestorer(dbContext);
                TestSystemModel model2 = restorer.Restore();

                CompareModels(model1, model2);
            }
        }

        private static void CompareModels(TestSystemModel model1, TestSystemModel model2)
        {
            StringWriter writer1 = new StringWriter(new StringBuilder());
            var reportGenerator1 = new ModelReporter(writer1);
            reportGenerator1.GenerateReport(model1);

            StringWriter writer2 = new StringWriter(new StringBuilder());
            var reportGenerator2 = new ModelReporter(writer2);
            reportGenerator2.GenerateReport(model2);

            String report1Content = writer1.ToString();
            String report2Content = writer2.ToString();

            Console.WriteLine(report1Content);

            Console.WriteLine("================================================================");
            Console.WriteLine();

            Console.WriteLine(report2Content);

            Console.WriteLine("================================================================");
            Console.WriteLine();

            Console.WriteLine(report1Content.Equals(report2Content) ? "PASSED: Models match" : "FAILED: Models mismatch");
        }
    }
}
