namespace MainLogic.Exceptions;

public class NotLoggedInException : Exception
{
    public NotLoggedInException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NotLoggedInException(string message)
        : base(message)
    {
    }

    public NotLoggedInException()
    {
    }
}