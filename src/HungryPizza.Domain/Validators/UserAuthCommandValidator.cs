using FluentValidation;
using HungryPizza.Domain.Commands.Autenticacao;
using HungryPizza.Domain.Commands.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizza.Domain.Validators
{
    public class UserAuthCommandValidator : AbstractValidator<AuthCommand>
    {
        public UserAuthCommandValidator()
        {

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField);

        }
    }
}
