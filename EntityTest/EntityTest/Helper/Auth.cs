using System.Security.Cryptography;
using System.Text;

namespace EntityTest.Helper
{

    public class Auth
    {
        public string salt { get; }

        public Auth()
        {
            salt = Encoding.UTF8.GetString(GetSalt());
        }

        public static bool verifyPassword(string password, string hashedPassword, string mysalt)
        {
            return HashPassword(password, mysalt) == hashedPassword;

        }

        public static string HashPassword(string password, string mysalt)
        {
            byte[] salt = Encoding.UTF8.GetBytes(mysalt);
            byte[] pwdByte = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[salt.Length + pwdByte.Length];
            StringBuilder sb;

            Array.Copy(salt, 0, saltedPasswordBytes, 0, salt.Length);
            Array.Copy(pwdByte, 0, saltedPasswordBytes, salt.Length, pwdByte.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(saltedPasswordBytes);

                sb = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

            }

            return sb.ToString();
        }




        private static byte[] GetSalt()
        {
            byte[] salt = new byte[16]; // 16 bytes = 128 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }




    }
}
