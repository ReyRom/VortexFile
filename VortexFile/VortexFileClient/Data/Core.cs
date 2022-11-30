namespace VortexFileClient.Data
{
    public static class Core
    {
        static VortexFileMySqlContext? context;
        public static VortexFileMySqlContext Context { get { return context ??= new VortexFileMySqlContext(); } }
    }
}
