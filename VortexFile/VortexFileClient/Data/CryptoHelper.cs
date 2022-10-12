using System.Security.Cryptography;
using System.Text;

namespace VortexFileClient.Data
{
    public static class CryptoHelper
    {
        public static string EncryptString(this string input)
        {
            byte[] hash;
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        public static void EncryptStream(this Stream input, Stream output, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                byte[] iv = aes.IV;
                output.Write(iv, 0, iv.Length);
                using (CryptoStream cs = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write, true))
                {
                    input.CopyTo(cs);
                }
            }
        }

        public static void DecryptStream(this Stream inputStream, Stream output, byte[] key)
        {
            byte[] iv = new byte[16];
            inputStream.Read(iv);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                using (CryptoStream cs = new CryptoStream(inputStream, aes.CreateDecryptor(), CryptoStreamMode.Read, true))
                {
                    cs.CopyTo(output);
                }
            }
        }
    }
}
