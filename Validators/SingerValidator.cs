
using FluentValidation;
using ValidarModelComMinimalAPI.Dtos;

namespace ValidarModelComMinimalAPI.Validators;

public class SingerValidator : AbstractValidator<SingerDTO>
{
    public SingerValidator() 
    {
        RuleFor(s => s.Name)
        .NotEmpty()
        .NotNull()
        .WithMessage("O nome precisa ser preenchido");

        RuleFor(s => s.LastName)
        .NotEmpty()
        .NotNull()
        .WithMessage("O sobrenome precisa ser preenchido");

        RuleFor(s => s.Age)
        .NotEmpty()
        .NotNull()
        .WithMessage("A idade precisa ser preenchida");
    }
}