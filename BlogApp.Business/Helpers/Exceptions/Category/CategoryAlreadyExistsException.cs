namespace BlogApp.Business.Helpers.Exceptions.Category;

public class CategoryAlreadyExistsException : Exception
{
    public CategoryAlreadyExistsException() : base("Category already exists")
    {
    }

    public CategoryAlreadyExistsException(string? message) : base(message)
    {
    }
}