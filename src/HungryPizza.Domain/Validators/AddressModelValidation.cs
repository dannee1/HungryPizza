using FluentValidation;
using HungryPizza.Domain.Models;

namespace HungryPizza.Domain.Validators
{
    public class AddressModelValidation : AbstractValidator<AddressModel>
    {
        public AddressModelValidation()
        {
            RuleFor(x => x.Neighborhood)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.ZipCode)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(8)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Complement)
               .MaximumLength(20)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.City)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(50)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Number)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(10)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.AddressName)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(80)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.State)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(2)
               .WithMessage(ErrorMessages.MaxLen);
        }
    }
}
