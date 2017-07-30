using TestingSystem.Model.Questions;

namespace TestingSystem.Repository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category FindByName(string name);
    }
}