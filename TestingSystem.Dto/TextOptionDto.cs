using System;
using System.Collections.Generic;

namespace TestingSystem.Dto
{
    public class TextOptionDto:DomainEntityDto<TextOptionDto>
    {
        public string Text { get; private set; }
        public bool IsCorrect { get; set; }

        public TextOptionDto(Guid domainId, bool show, string text, bool isCorrect)
            : base(domainId, show)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{Text};
        }

        public override string ToString()
        {
            return $"{nameof(Text)}: {Text}";
        }
    }
}