namespace BlogApp.Business.Helpers.Exceptions.Common;

public class NegativeIdException : Exception
{
    public NegativeIdException() : base("Id cannot be zero or negative")
    {
    }

    public NegativeIdException(string? message) : base(message)
    {
    }
}