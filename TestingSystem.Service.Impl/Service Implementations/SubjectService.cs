using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using TestingSystem.Dto;
using TestingSystem.Exceptions.DomainLogic;
using TestingSystem.Model.Questions;
using TestingSystem.Repository;

namespace TestingSystem.Service.Impl
{
    public class SubjectService:ISubjectService
    {
        [Dependency]
        protected ISubjectRepository subjectRepository { get; set; }

        [Dependency]
        protected ICategoryRepository categoryRepository { get; set; }

        public IList<Guid> ViewAll()
        {
            return subjectRepository.SelectAllDomainIds().ToList();
        }

        public SubjectDto View(Guid domainId)
        {
            Subject subject = ResolveSubject(domainId);
            return subject.ToDto();
        }

        public void Hide(Guid domainId)
        {
            Subject subject = ResolveSubject(domainId);
            subject.Hide();
        }

        public void Unhide(Guid domainId)
        {
            Subject subject = ResolveSubject(domainId);
            subject.UnHide();
        }

        public Guid Create(string name, string description, Guid categoryId, TimeSpan maxDuration, byte[] image)
        {
            Subject s = subjectRepository.FindByName(name);
            if(s!=null)
                throw new DuplicateNamedEntityException(typeof(Subject),name);

            Category category = categoryRepository.FindByDomainId(categoryId);
            if(category==null)
                throw new ArgumentException($"No such category ID:{categoryId}");

            Subject subject =new Subject(Guid.NewGuid(),name,description,category,maxDuration,image);
            subjectRepository.Add(subject);

            return subject.Id;
        }

        public void Rename(Guid subjectId, string newName)
        {
            Subject s = subjectRepository.FindByName(newName);
            if (s != null)
                throw new DuplicateNamedEntityException(typeof(Subject), newName);

            Subject subject = ResolveSubject(subjectId);
            subject.Name = newName;
        }

        public void ChangeDescription(Guid subjectId, string newDescription)
        {
            Subject subject = ResolveSubject(subjectId);
            subject.Description = newDescription;
        }

        public void ChangeImage(Guid subjectId, byte[] image)
        {
            Subject subject = ResolveSubject(subjectId);
            subject.Image = image;
        }

        public void ChangeCaegory(Guid subjectId, Guid newCategoryId)
        {
            Category category = categoryRepository.FindByDomainId(newCategoryId);
            if (category == null)
                throw new ArgumentException($"No such category ID:{newCategoryId}");

            Subject subject = ResolveSubject(subjectId);
            subject.Category = category;
        }

        public void ChangeMaxDuration(Guid subjectId, TimeSpan maxDuration)
        {
            Subject subject = ResolveSubject(subjectId);
            subject.MaxDuration = maxDuration;
        }

        private Subject ResolveSubject(Guid subjectId)
        {
            return ServiceUtils.ResolveEntity(subjectRepository, subjectId);
        }
    }
}