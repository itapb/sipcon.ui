
using System.Collections;
using System.Security.Cryptography;
using System.Text;
namespace Sipcon.WebApp.Client.Helper
{
    internal static class HelperCryptography
    {
        public static string EncryptPasswordSHA(string password, string salt)
        {
            string contenido = password + salt;
            SHA512 sha512 = SHA512.Create();
            byte[] salida = Encoding.ASCII.GetBytes(contenido);

            for (int i = 1; i <= 13; i++)
            {
                salida = sha512.ComputeHash(salida);
            }
            sha512.Clear();
            
            //return await Task.FromResult(Encoding.UTF8.GetString(salida));
            return Encoding.ASCII.GetString(salida);
        }

        public static string GenerateSalt()
        {
            Random random = new Random();
            string salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int aleat = random.Next(65, 122);
                char letra = Convert.ToChar(aleat);
                salt += letra;
            }
            return salt;
        }


    }
}
