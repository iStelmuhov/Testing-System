using System;

namespace TestingSystem.Model.Questions
{
    public class TextOption:Utils.Entity
    {
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        protected TextOption()
        {
        }

        public TextOption(Guid domainId, string text, bool isCorrect) 
            : base(domainId)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}