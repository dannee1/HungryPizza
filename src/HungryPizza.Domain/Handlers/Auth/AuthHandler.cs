using MediatR;
using HungryPizza.Domain.Commands.Autenticacao;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Models;
using HungryPizza.Domain.Utils;
using HungryPizza.Domain.Validators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.Autenticacao
{
    public class AuthHandler : IRequestHandler<AuthCommand, GenericCommandResult>
    {
        private readonly IUserRepository _userRepository;

        public AuthHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericCommandResult> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserAuthCommandValidator();
            var results = validator.Validate(request);
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);

            var user = await _userRepository.Get(request.Login, PasswordEncrypt.Encrypt(request.Password));

            if (user is null)
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.WrongUser });

            var retorno = new UserModel { Login = user.EmailLogin, Name = user.Name, Token = Token.GenerateNewToken(user.EmailLogin) };
            return GenericCommandResult.Success(retorno);
        }
    }
}
