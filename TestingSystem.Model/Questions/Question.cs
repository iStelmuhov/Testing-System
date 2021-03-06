﻿using System;
using System.Collections.Generic;

namespace TestingSystem.Model.Questions
{
    public abstract class Question :Utils.Entity
    {
        public virtual Subject Subject { get; set; }
        public string QuestionText { get; set; }

        public abstract IList<string> GetPossibleAnswers();
        public abstract float CheckAnswer(params string[] answers);
        public abstract void AddAnswer(TextOption answer);
        public abstract void RemoveAnswer(Guid answerId);
        public abstract void EditAnswer(TextOption answer);
        public abstract QuestionType GetQuestionType();
        public abstract void ClearAnswers();

        protected Question(){}

        protected Question(Guid domainId, Subject subject, string questionText)
            : base(domainId)
        {
            Subject = subject;
            QuestionText = questionText;
        }
    }
}