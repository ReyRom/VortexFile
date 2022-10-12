namespace VortexFileClient.Extensions
{
    public static class Code
    {
        public static string Generate(int length)
        {
            string code = String.Empty;
            Random rnd = new Random();
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                code += ALF[rnd.Next(ALF.Length)];
            return code;
        }
    }
}
