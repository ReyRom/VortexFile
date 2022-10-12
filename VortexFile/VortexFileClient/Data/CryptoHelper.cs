using System.Security.Cryptography;

namespace VortexFileClient.Data
{
    public static class CryptoHelper
    {
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
