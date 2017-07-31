using System;
using System.Collections.Generic;

namespace TestingSystem.Dto
{
    public class CategoryDto:DomainEntityDto<CategoryDto>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }

        public CategoryDto(Guid domainId, bool show, string name, string description, byte[] image)
            : base(domainId, show)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[]{Name};
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Description)}: {Description}";
        }
    }
}