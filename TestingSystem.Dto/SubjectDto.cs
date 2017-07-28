using System;
using System.Collections.Generic;
using TestingSystem.Model.Questions;

namespace TestingSystem.Dto
{
    public class SubjectDto : DomainEntityDto<SubjectDto>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual CategoryDto Category { get; private set; }
        public TimeSpan MaxDuration { get; private set; }
        public byte[] Image { get; private set; }

        public SubjectDto(Guid domainId, string name, string description, CategoryDto category, TimeSpan maxDuration, byte[] image) : base(domainId)
        {
            Name = name;
            Description = description;
            Category = category;
            MaxDuration = maxDuration;
            Image = image;
        }


        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{Name,Category.Name};
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Category)}: {Category}, {nameof(MaxDuration)}: {MaxDuration}";
        }
    }
}