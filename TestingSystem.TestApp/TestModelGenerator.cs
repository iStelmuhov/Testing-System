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
            model.Accouts.Add(new Account(){ Id = Guid.NewGuid(), Email = "one@mail.ru",FirstName = "fOne",LastName = "lOne",UserRole = Role.User,Password = "12345",Image = new byte[20]});
        }

        public static void GenerateCategories(TestSystemModel model)
        {
            model.Categories.Add(new Category(){Id = Guid.NewGuid(),Description = "One desc",Name = "First Category"});

        }

        public static void GenerateSubjects(TestSystemModel model)
        {
            model.Subjects.Add(new Subject() { Id = Guid.NewGuid(), Description = "One desc", Name = "First Subject",Category = model.Categories[0],MaxDuration = TimeSpan.FromMinutes(20)});

        }

        public static void GenerateQuestions(TestSystemModel model)
        {
            model.Questions.Add(new SingleQuestion(){Id = Guid.NewGuid(),Subject = model.Subjects[0],Type=QuestionType.SingleAnswer,CorrectAnswer =new TextOption("First correct"),QuestionText = "Question one?",WrongAnswers = new List<TextOption>(){new TextOption("First wrong"),new TextOption("Second Wrong")}});
            model.Questions.Add(new MultiQestion() { Id = Guid.NewGuid(), Subject = model.Subjects[0], Type = QuestionType.SingleAnswer, CorrectAnswers =new HashSet<TextOption>(){ new TextOption("First correct"), new TextOption("Second correct"), }, QuestionText = "Question one?", WrongAnswers = new HashSet<TextOption>(){ new TextOption("First wrong"), new TextOption("Second Wrong") } });
            model.Questions.Add(new WriteQuestion() { Id = Guid.NewGuid(), Subject = model.Subjects[0], Type = QuestionType.SingleAnswer, QuestionText = "Question one?", PossibleAnswers = new List<TextOption>() { new TextOption("First possible"), new TextOption("Second possible") } });

        }

        public static void GenerateTestSessions(TestSystemModel model)
        {
            model.TestSessions.Add(new TestSession(){Id = Guid.NewGuid(),Duration = TimeSpan.FromMinutes(12),IsEnded = true,User = model.Accouts[0],StartTime = DateTime.Now,EndTime = DateTime.MaxValue,TestInfo = new TestInfo(){Id = Guid.NewGuid(),SubjectId = model.Subjects[0].Id,Questions = new List<Question>(){model.Questions[0],model.Questions[1],model.Questions[2]}}});

        }

        public static void GenerateTestResults(TestSystemModel model)
        {
            model.TestResults.Add(new TestResult(){Id = Guid.NewGuid(),Score = 10,UserId = model.Accouts[0].Id,TestSessionId = model.TestSessions[0].Id});

        }
    }
}