using TestingSystem.Model.Questions;

namespace TestingSystem.Repository
{
    public interface ISubjectRepository:IRepository<Subject>
    {
        Subject FindByName(string name);
    }
}