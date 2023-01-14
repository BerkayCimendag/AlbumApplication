using System.Security.Cryptography;
using System.Text;

namespace AlbumApplication.Data.Classes
{
    public static class Cryptograph
    {
        public static string Cryptography(string password)
        {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }
            return Convert.ToBase64String(hashBytes);


        }
    }
}
