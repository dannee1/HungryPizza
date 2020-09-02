using FluentValidation;
using HungryPizza.Domain.Commands.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizza.Domain.Validators
{
    public class NewOrderCommandValidator : AbstractValidator<NewOrderCommand>
    {
        public NewOrderCommandValidator()
        {

            RuleFor(x => x.Pizzas)
                .Must(x => x.Count <= 10)
                .WithMessage(ErrorMessages.MaxPizzasAllowed);
            RuleForEach(x => x.Pizzas)
                .ChildRules(w =>
                {
                    w
                        .RuleFor(flavor => flavor.Flavors.Count)
                        .LessThanOrEqualTo(2)
                        .WithMessage(ErrorMessages.MaxFlavorsAllowed);
                });
            
        }
    }
}
