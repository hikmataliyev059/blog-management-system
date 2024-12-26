namespace BlogApp.Business.Helpers.Exceptions.Category;

public class CategoryNullException : Exception
{
    public CategoryNullException() : base("Category not found")
    {
    }

    public CategoryNullException(string? message) : base(message)
    {
    }
}