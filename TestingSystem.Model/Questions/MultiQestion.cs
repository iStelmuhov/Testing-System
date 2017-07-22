using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Model.Questions
{
    public class MultiQestion:Question
    {
        public virtual ISet<TextOption> WrongAnswers { get; set; }
        public virtual ISet<TextOption> CorrectAnswers { get; set; }

        public MultiQestion()
        {
            Type=QuestionType.MultiAnswer;
            
        }

        public override IList<TextOption> GetPossibleAnswers()
        {
            var answers = WrongAnswers;
            answers.UnionWith(CorrectAnswers);
            return answers.ToList();
        }

        public override bool CheckAnswer(params string[] answers)
        {
            if (answers == null || answers.Length < 1)
                throw new ArgumentException("Invalid answers count!");

            return true; //CorrectAnswers.SetEquals(answers); TODO
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(WrongAnswers)}: {WrongAnswers}, {nameof(CorrectAnswers)}: {CorrectAnswers}";
        }
    }
}