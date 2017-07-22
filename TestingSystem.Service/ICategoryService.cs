using System;
using TestingSystem.Model.Questions;

namespace TestingSystem.Service
{
    public interface ICategoryService:IDomainEntityService<Category>
    {
        Guid Create(string name, string description, byte[] image);
        void Rename(Guid categoryId, string newName);
        void ChangeDescription(Guid categoryId, string newDescription);
        void ChangeImage(Guid categoryId, byte[] image);
    }
}