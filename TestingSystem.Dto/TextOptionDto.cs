using System;
using System.Collections.Generic;

namespace TestingSystem.Dto
{
    public class TextOptionDto:DomainEntityDto<TextOptionDto>
    {
        public string Text { get; private set; }

        public TextOptionDto(Guid domainId, string text) : base(domainId)
        {
            Text = text;
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