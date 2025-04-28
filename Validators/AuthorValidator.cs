using FluentValidation;
using MK.DTO;

namespace MK.Validators;

public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
{
    public AuthorCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Ім'я автора обов'язкове")
            .MaximumLength(100)
            .WithMessage("Ім'я автора не повинно перевищувати 100 символів");
    }
}

public class AuthorUpdateDtoValidator : AbstractValidator<AuthorUpdateDto>
{
    public AuthorUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Ім'я автора обов'язкове")
            .MaximumLength(100)
            .WithMessage("Ім'я автора не повинно перевищувати 100 символів");
    }
}