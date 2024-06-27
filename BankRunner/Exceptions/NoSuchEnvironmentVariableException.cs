namespace BankRunner.Exceptions;

public class NoSuchEnvironmentVariableException : Exception
{
    public NoSuchEnvironmentVariableException(string message)
        : base(message)
    {
    }

    public NoSuchEnvironmentVariableException()
    {
    }

    public NoSuchEnvironmentVariableException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}