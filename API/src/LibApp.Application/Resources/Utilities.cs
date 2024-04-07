using System.Security.Cryptography;
using System.Text;

namespace LibApp.Application.Resources
{
    public class Utilities
    {
        public static string EncryptKey(string key) {
            StringBuilder sk = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                {
                    sk.Append(b.ToString("x2"));
                }
            }

            return sk.ToString();        
        }
    }
}
