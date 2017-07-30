namespace TestingSystem.Exceptions.DomainLogic
{
    public class NoCorrectAnswersException:DomainLogicException
    {
        public NoCorrectAnswersException(string questionName)
            : base($"No correct answers in {questionName}")
        {}
    }
}