using FluentValidation;

namespace BlogApp.Business.DTOs.Category;

public record AddCategoryDto
{
    public string Name { get; set; }
}

public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
{
    public AddCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name cannot be empty")
            .MaximumLength(20)
            .WithMessage("Name cannot exceed 20 characters");
    }
}