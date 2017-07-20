using System;

namespace TestingSystem.Model.Questions
{
    public class TextOption
    {

        public Guid Id { get; set; }
        public string Text { get; set; }

        public TextOption()
        {
        }

        public TextOption(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Text)}: {Text}";
        }
    }
}