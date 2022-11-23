using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace VortexFileClient.Data
{
    public static class CryptoHelper
    {
        public static string EncryptString(this string input)
        {
            byte[] hash;
            using (var sha1 = SHA1.Create())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            var sb = new StringBuilder();
            foreach (byte b in hash) 
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }
        public static byte[] GetKey(this string input, int length)
        {
            byte[] hash = new byte[length];
            using (var sha1 = SHA1.Create())
            {
                var temp = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
                for (int i = 0; i < hash.Length; i++)
                {
                    hash[i] = temp[i];
                }
            }
            return hash;
        }

        public static void EncryptStream(this Stream input, Stream output, byte[] key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                byte[] iv = Encoding.ASCII.GetBytes("ROMAN_SWAROWSKIY");
                aes.Padding = PaddingMode.Zeros;
                using (CryptoStream cs = new CryptoStream(output, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    int data;
                    while ((data = input.ReadByte()) != -1)
                        cs.WriteByte((byte)data);
                }
            }
        }

        public static void DecryptStream(this Stream input, Stream output, byte[] key)
        {
            byte[] iv = Encoding.ASCII.GetBytes("ROMAN_SWAROWSKIY");
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.Zeros;
                using (CryptoStream cs = new CryptoStream(input, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        output.WriteByte((byte)data);
                }
            }
        }
    }
}
