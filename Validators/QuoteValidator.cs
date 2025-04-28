using FluentValidation;
using MK.DTO;

namespace MK.Validators;

public class QuoteCreateDtoValidator : AbstractValidator<QuoteCreateDto>
{
    public QuoteCreateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Текст цитати є обов'язковим")
            .MaximumLength(500)
            .WithMessage("Текст цитати не повинен перевищувати 500 символів");

        RuleFor(x => x.AuthorId)
            .GreaterThan(0)
            .WithMessage("Id автора має бути більше 0");

        RuleForEach(x => x.Tags)
            .NotEmpty()
            .WithMessage("Ім'я тега не може бути порожнім");
    }
}

public class QuoteUpdateDtoValidator : AbstractValidator<QuoteUpdateDto>
{
    public QuoteUpdateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Текст цитати є обов'язковим")
            .MaximumLength(500)
            .WithMessage("Текст цитати не повинен перевищувати 500 символів");

        RuleFor(x => x.AuthorId)
            .GreaterThan(0)
            .WithMessage("Id автора має бути більше 0");

        RuleForEach(x => x.Tags)
            .NotEmpty()
            .WithMessage("Ім'я тега не може бути порожнім");
    }
}