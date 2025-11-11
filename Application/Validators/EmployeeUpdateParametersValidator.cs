using Application.Dtos;
using FluentValidation;

namespace Application.Validators;

public class EmployeeUpdateParametersValidator : AbstractValidator<EmployeeUpdateDto>
{
  public EmployeeUpdateParametersValidator()
  {
    RuleFor(x => x.EmployeeId).NotNull().GreaterThanOrEqualTo(0);
    RuleFor(x => x.Phone).PhoneNumberMustBeValid();
  }
}
