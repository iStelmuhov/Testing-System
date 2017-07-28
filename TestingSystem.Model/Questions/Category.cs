using System;

namespace TestingSystem.Model.Questions
{
    public class Category :Utils.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        protected Category(){}

        public Category(Guid domainId, string name, string description, byte[] image) 
            : base(domainId)
        {
            Name = name;
            Description = description;
            Image = image;
        }
    }
}