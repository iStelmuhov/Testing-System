using System;
using TestingSystem.Dto;
using TestingSystem.Model.Questions;

namespace TestingSystem.Service
{
    public interface ISubjectService:IDomainEntityService<SubjectDto>
    {
        Guid Create(string name, string description, Guid categoryId, TimeSpan maxDuration, byte[] image);
        void Rename(Guid subjectId, string newName);
        void ChangeDescription(Guid subjectId, string newDescription);
        void ChangeImage(Guid subjectId, byte[] image);
        void ChangeCaegory(Guid subjectId,Guid newCategoryId);
        void ChangeMaxDuration(Guid subjectId, TimeSpan maxDuration);
    }
}