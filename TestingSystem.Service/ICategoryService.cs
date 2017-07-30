using System;
using TestingSystem.Dto;
using TestingSystem.Model.Questions;

namespace TestingSystem.Service
{
    public interface ICategoryService:IDomainEntityService<CategoryDto>
    {
        Guid Create(string name, string description, byte[] image);
        void Rename(Guid categoryId, string newName);
        void ChangeDescription(Guid categoryId, string newDescription);
        void ChangeImage(Guid categoryId, byte[] image);
    }
}