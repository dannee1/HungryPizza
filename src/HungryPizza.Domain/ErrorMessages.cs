using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain
{
    public class ErrorMessages
    {
        public static string PassNoEqual = "As senhas não coincidem";
        public static string MaxLen = "O campo {PropertyName} precisa ter no máximo {MaxLength} caracteres";
        public static string EmptyField = "O campo {PropertyName} precisa ser preenchido";
        public static string EmptyPizzas = "É necessário adicionar pelo menos uma pizza ao pedido";
        public static string MaxPizzasAllowed = "É permitido adicionar até 10 pizzas ao mesmo pedido";
        public static string MaxFlavorsAllowed = "É permitido adicionar até 2 sabores a mesma pizza";
        public static string WrongUser = "Usuário ou senha incorretos";
        public static string UserAlreadyExists = "Já existe um usuário com esse login";
        public static string UserNotExists = "Usuário não encontrado";
    }
}
