using System;

namespace TestingSystem.Model.Questions
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public TimeSpan MaxDuration { get; set; }
        public byte[] Image { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Category)}: {Category}, {nameof(MaxDuration)}: {MaxDuration}";
        }
    }
}