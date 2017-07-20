using System.Collections.Generic;
using TestingSystem.Model.Accounts;
using TestingSystem.Model.Questions;
using TestingSystem.Model.Session;

namespace TestingSystem.TestApp
{
    public class TestSystemModel
    {
        public List<Account> Accouts { get; }
        public List<Category> Categories { get; }
        public List<Question> Questions { get; }
        public List<Subject> Subjects { get; }
        public List<TestResult> TestResults { get; }
        public List<TestSession> TestSessions { get; }

        public TestSystemModel()
        {
            Accouts=new List<Account>();
            Categories=new List<Category>();
            Questions=new List<Question>();
            Subjects=new List<Subject>();
            TestResults=new List<TestResult>();
            TestSessions=new List<TestSession>();
        }
    }
}