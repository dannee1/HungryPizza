using MediatR;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Models;
using System;
using System.Collections.Generic;

namespace HungryPizza.Domain.Commands.User
{
    public class GetOrderFromUserCommand : IRequest<GenericCommandResult>
    {
        public GetOrderFromUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
