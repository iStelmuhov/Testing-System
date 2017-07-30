using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Model.Questions;

namespace TestingSystem.Repository
{
    public interface IQuestionRepository:IRepository<Question>
    {
        IQueryable<Question> FindAllSubjectQuestions(Guid subjectId);
    }
}