using FluentValidation;
using InExTrack.Domain.Models;

namespace InExTrack.Application.Validators
{
    public class UserRequestValidator:AbstractValidator<User>
    {
        public UserRequestValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty()
                .WithMessage("Name is empty!");
            RuleFor(x => x.PhoneNumber).NotEmpty()
                .MaximumLength(12)
                .WithMessage("Width cannot more 12 symbol!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is empty!")
                .EmailAddress()
                .WithMessage("Email is not valid!");
        }
    }
}
