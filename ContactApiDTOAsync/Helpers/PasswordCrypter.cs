using System.Text;

namespace ContactApiDTOAsync.Helpers
{
    public class PasswordCrypter
    {

        public static string Encrypt(string password, string key)
        {
            if (string.IsNullOrEmpty(password)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + key));
        }

    }
}
