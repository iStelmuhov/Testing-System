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
    public class CategoryService:ICategoryService
    {
        [Dependency] protected ICategoryRepository categoryRepository { get; set; }


        public IList<Guid> ViewAll()
        {
            return categoryRepository.SelectAllDomainIds().ToList();
        }

        public CategoryDto View(Guid domainId)
        {
            Category category = ResolveCategory(domainId);
            return category.ToDto();
        }

        public void Hide(Guid domainId)
        {
            Category category = ResolveCategory(domainId);
            category.Hide();
        }

        public void Unhide(Guid domainId)
        {
            Category category = ResolveCategory(domainId);
            category.UnHide();
        }

        public Guid Create(string name, string description, byte[] image)
        {
            Category c = categoryRepository.FindByName(name);
            if(c != null)
                throw new DuplicateNamedEntityException(typeof(Category),name);

            Category category = new Category(Guid.NewGuid(),name,description,image);
            categoryRepository.Add(category);
            return category.Id;
        }

        public void Rename(Guid categoryId, string newName)
        {
            Category c = ResolveCategory(categoryId);
            c.Name = newName;
        }

        public void ChangeDescription(Guid categoryId, string newDescription)
        {
            Category c = ResolveCategory(categoryId);
            c.Description = newDescription;
        }

        public void ChangeImage(Guid categoryId, byte[] image)
        {
            Category c = ResolveCategory(categoryId);
            c.Image = image;
        }

        private Category ResolveCategory(Guid categoryId)
        {
            return ServiceUtils.ResolveEntity(categoryRepository, categoryId);
        }
    }
}