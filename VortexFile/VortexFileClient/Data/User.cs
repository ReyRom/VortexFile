namespace VortexFileClient.Data
{
    public class User
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Username { get; set; }
        public string? Phone { get; set; }
    }
}