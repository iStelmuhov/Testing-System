using System;
using System.Collections.Generic;

namespace TestingSystem.Model.Questions
{
    public abstract class Question
    {
        public Guid Id { get; set; }
        public virtual Subject Subject { get; set; }
        public QuestionType Type { get;  set; }
        public string QuestionText { get; set; }
        public abstract IList<TextOption> GetPossibleAnswers();
        public abstract bool CheckAnswer(params string[] answers);

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Subject)}: {Subject}, {nameof(Type)}: {Type}, {nameof(QuestionText)}: {QuestionText}";
        }
    }
}