using FluentValidation;

namespace PDITWA.DTOs.Validators
{
    public class TestUserDTOValidator : AbstractValidator<TestUserDTO>
    {
        public TestUserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().MinimumLength(9).MinimumLength(9);
        }
    }
}
