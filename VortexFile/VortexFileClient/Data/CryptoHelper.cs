using System.Drawing;
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

        public static void EncryptStream(this Stream input, Stream output, byte[] key)
        {
            using (var des = DES.Create())
            {
                des.Key = key;
#warning Переопределить соль
                byte[] iv = Encoding.ASCII.GetBytes("ABCDEFGH");
                des.Padding = PaddingMode.Zeros;
                using (CryptoStream cs = new CryptoStream(output, des.CreateEncryptor(key,iv), CryptoStreamMode.Write))
                {
                    int data;
                    while ((data = input.ReadByte()) != -1)
                        cs.WriteByte((byte)data);
                }
            }
        }

        public static void DecryptStream(this Stream input, Stream output, byte[] key)
        {
#warning Переопределить соль
            byte[] iv = Encoding.ASCII.GetBytes("ABCDEFGH");
            using (var des = DES.Create()) 
            { 
                des.Key = key;
                des.IV = iv;
                des.Padding = PaddingMode.Zeros;
                using (CryptoStream cs = new CryptoStream(input, des.CreateDecryptor(key,iv), CryptoStreamMode.Read))
                {
                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        output.WriteByte((byte)data);
                }
            }
        }
    }
}
