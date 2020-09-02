using System.Security.Cryptography;
using System.Text;

namespace HungryPizza.Domain.Utils
{
    public static class PasswordEncrypt
    {
        public static string Encrypt(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}
