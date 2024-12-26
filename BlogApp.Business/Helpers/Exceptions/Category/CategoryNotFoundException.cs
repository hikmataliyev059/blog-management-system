namespace BlogApp.Business.Helpers.Exceptions.Category;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException() : base("Category not found")
    {
    }

    public CategoryNotFoundException(string? message) : base(message)
    {
    }
}