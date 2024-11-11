using Application.Dtos;
using FluentValidation;

namespace Application.Validators;

public class ProfileUpdatingParametersValidator : AbstractValidator<ProfileUpdatingParameters>
{
    public ProfileUpdatingParametersValidator()
    {
        RuleFor(x => x.Phone).PhoneNumberMustBeValid();
    }
}