using MediatR;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Utils;
using HungryPizza.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.NewUserUserHandler
{

    public class NewUserHandler : IRequestHandler<NewUserCommand, GenericCommandResult>
    {
        private readonly IUserRepository _userRepository;
        public NewUserHandler(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<GenericCommandResult> Handle(NewUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Login);
            if (user != null)
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.UserAlreadyExists });

            var validator = new NewUserCommandValidator();
            var results = validator.Validate(request);
            
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);


            var passEncrypt = PasswordEncrypt.Encrypt(request.Password);
            var addresss = request.Addresses.Select(s => new Address(s.AddressName, s.Number, s.Complement, s.Neighborhood, s.ZipCode, s.City, s.State)).ToList();
            var User = new User(request.Name, request.Login, passEncrypt, request.DDD, request.Phone, addresss);
            await _userRepository.Create(User);
            return GenericCommandResult.Success();
        }
    }
}
