using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Commands.Autenticacao
{
    public class AuthCommand : IRequest<GenericCommandResult>
    {
        public AuthCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
    }
}
