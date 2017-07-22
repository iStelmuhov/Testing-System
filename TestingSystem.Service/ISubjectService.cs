using System;
using TestingSystem.Model.Questions;

namespace TestingSystem.Service
{
    public interface ISubjectService:IDomainEntityService<Subject>
    {
        Guid Create(string name, string description, Category category, TimeSpan maxDuration, byte[] image);
        void Rename(Guid subjectId, string newName);
        void ChangeDescription(Guid subjectId, string newDescription);
        void ChangeImage(Guid subjectId, byte[] image);
        void ChangeCaegory(Guid subjectId,Category newCategory);
        void ChangeMaxDuration(Guid subjectId, TimeSpan maxDuration);
    }
}