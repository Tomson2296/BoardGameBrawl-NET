namespace BoardGameBrawl.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object obj) : base($"{name} ({obj}) was not found")
        {

        }
    }
}
