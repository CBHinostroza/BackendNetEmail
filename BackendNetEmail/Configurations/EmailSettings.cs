namespace BackendNetEmail.Configurations
{
    public class EmailSettings
    {
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public string Host { get; set; } = string.Empty;
        public bool UseDefaultCredentials { get; set; }
    }
}
