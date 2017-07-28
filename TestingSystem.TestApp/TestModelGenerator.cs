using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TestingSystem.Model.Accounts;
using TestingSystem.Model.Questions;
using TestingSystem.Model.Session;

namespace TestingSystem.TestApp
{
    public class TestModelGenerator
    {
        public static TestSystemModel GenerateTestData()
        {
            TestSystemModel model=new TestSystemModel();
            GenerateAccounts(model);
            GenerateCategories(model);
            GenerateSubjects(model);
            GenerateQuestions(model);
            GenerateTestSessions(model);
            GenerateTestResults(model);

            return model;
        }

        public static void GenerateAccounts(TestSystemModel model)
        {
            model.Accouts.Add(new Account(Guid.Empty, "fName","lName",Role.User, "1234","mail1@mail.ru",new byte[1]));
        }

        public static void GenerateCategories(TestSystemModel model)
        {
            model.Categories.Add(new Category(Guid.NewGuid(),"Category One","Description of category one",new byte[1]));

        }

        public static void GenerateSubjects(TestSystemModel model)
        {
            model.Subjects.Add(new Subject(Guid.NewGuid(),"Subject one","Description of Subject one",model.Categories[0],TimeSpan.FromMinutes(20),new byte[1]));

        }

        public static void GenerateQuestions(TestSystemModel model)
        {
            model.Questions.Add(new SingleQuestion(Guid.NewGuid(),model.Subjects[0],"Single question one?",new List<TextOption>(){new TextOption(Guid.NewGuid(), "Answer one"),new TextOption(Guid.NewGuid(),"Answer two")},new TextOption(Guid.NewGuid(), "Correct answer")));
            model.Questions.Add(new MultiQestion(Guid.NewGuid(),model.Subjects[0],"Multi question one?",new HashSet<TextOption>() { new TextOption(Guid.NewGuid(), "Answer one"), new TextOption(Guid.NewGuid(), "Answer two") }, new HashSet<TextOption>(){new TextOption(Guid.NewGuid(),"Correct Answer one"),new TextOption(Guid.NewGuid(),"Correct answer two")} ));
            model.Questions.Add(new WriteQuestion(Guid.NewGuid(),model.Subjects[0],"Write question one?",new List<TextOption>(){new TextOption(Guid.NewGuid(), "Yes"),new TextOption(Guid.NewGuid(),"da")}));

        }

        public static void GenerateTestSessions(TestSystemModel model)
        {
            model.TestSessions.Add(new TestSession(Guid.NewGuid(),model.Accouts[0].Id,new TestInfo(Guid.NewGuid(),model.Subjects[0].Id,new List<Question>(){model.Questions[0],model.Questions[1],model.Questions[2]})));

        }

        public static void GenerateTestResults(TestSystemModel model)
        {
            model.TestResults.Add(new TestResult(Guid.NewGuid(),model.Accouts[0].Id,model.TestSessions[0].Id,10));

        }
    }
}