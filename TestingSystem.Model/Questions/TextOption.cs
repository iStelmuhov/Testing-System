using System;

namespace TestingSystem.Model.Questions
{
    public class TextOption:Utils.Entity
    {
        public string Text { get; set; }

        protected TextOption()
        {
        }

        public TextOption(Guid domainId, string text) 
            : base(domainId)
        {
            Text = text;
        }
    }
}