using System;

namespace TestingSystem.Model.Questions
{
    public class Subject :Utils.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public TimeSpan MaxDuration { get; set; }
        public byte[] Image { get; set; }

        protected Subject(){}

        public Subject(Guid domainId, string name, string description, Category category, TimeSpan maxDuration, byte[] image) : base(domainId)
        {
            Name = name;
            Description = description;
            Category = category;
            MaxDuration = maxDuration;
            Image = image;
        }
    }
}