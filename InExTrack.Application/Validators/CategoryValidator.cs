using FluentValidation;
using InExTrack.Domain.Enums;
using InExTrack.Domain.Models;

namespace InExTrack.Application.Validators;

public class CategoryValidator:AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Category name cannot be empty!")
            .MaximumLength(50)
            .WithMessage("Category name cannot exceed 50 characters!");

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Category type cannot be empty!")
            .Must(type => type == CategoryTypeEnum.Expense || type == CategoryTypeEnum.Income)
            .WithMessage("Category type must be either 'income' or 'expense'!");
    }
}
