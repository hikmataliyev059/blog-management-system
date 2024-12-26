namespace BlogApp.Business.Helpers.UserExceptions;

public class UserRegisterException : Exception
{
    public UserRegisterException() : base("Registration Failed")
    {
    }

    public UserRegisterException(string? message) : base(message)
    {
    }
}