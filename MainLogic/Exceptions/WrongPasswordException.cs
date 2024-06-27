namespace MainLogic.Exceptions;

public class WrongPasswordException : Exception
{
    public WrongPasswordException(string message)
        : base(message)
    {
    }

    public WrongPasswordException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongPasswordException()
        : base("Wrong pin")
    {
    }
}