namespace MainLogic.Exceptions;

public class NotEnoughMoneyException : Exception
{
    public NotEnoughMoneyException(string message)
        : base(message)
    {
    }

    public NotEnoughMoneyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NotEnoughMoneyException()
        : base("You can`t withdraw money, you haven`t got that much")
    {
    }
}