using FluentValidation;
using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizza.Domain.Validators
{
    public class NewUserCommandValidator : AbstractValidator<NewUserCommand>
    {
        public NewUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.DDD)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(2)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Login)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(100)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(100)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.ConfirmPassword)
              .NotEmpty()
              .WithMessage(ErrorMessages.EmptyField)
              .MaximumLength(100)
              .WithMessage(ErrorMessages.MaxLen)
              .Equal(x => x.Password)
              .WithMessage(ErrorMessages.PassNoEqual);
            RuleFor(x => x.Phone)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(9)
               .WithMessage(ErrorMessages.MaxLen);

            RuleForEach(end => end.Addresses)
                .ChildRules(w =>
                {
                    w.RuleFor(x => x.Neighborhood)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(100)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.ZipCode)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(8)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Complement)
                    .MaximumLength(20)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.City)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(50)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Number)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(10)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.AddressName)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(80)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.State)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(2)
                    .WithMessage(ErrorMessages.MaxLen);
                });
        }
    }
}
