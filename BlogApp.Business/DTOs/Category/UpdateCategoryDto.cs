using FluentValidation;

namespace BlogApp.Business.DTOs.Category;

public record UpdateCategoryDto
{
    public string Name { get; set; }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);
    }
}