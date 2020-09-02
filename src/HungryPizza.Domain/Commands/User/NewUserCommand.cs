using MediatR;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Models;
using System.Collections.Generic;

namespace HungryPizza.Domain.Commands.User
{
    public class NewUserCommand : IRequest<GenericCommandResult>
    {
        public NewUserCommand(string name, string login, string password, string confirmPassword, List<AddressModel> addresss, string ddd, string phone)
        {
            Name = name;
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
            Addresses = addresss;
            DDD = ddd;
            Phone = phone;
        }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<AddressModel> Addresses { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
    }
}
