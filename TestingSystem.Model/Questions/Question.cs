using System;
using System.Collections.Generic;

namespace TestingSystem.Model.Questions
{
    public abstract class Question :Utils.Entity
    {
        public virtual Subject Subject { get; set; }
        public QuestionType Type { get;  set; }
        public string QuestionText { get; set; }

        public abstract IList<TextOption> GetPossibleAnswers();
        public abstract bool CheckAnswer(params string[] answers);

        protected Question(){}

        protected Question(Guid domainId, Subject subject, string questionText)
            : base(domainId)
        {
            Subject = subject;
            QuestionText = questionText;
            Type = QuestionType.None;
        }
    }
}