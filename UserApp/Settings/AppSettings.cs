namespace UserApp.Api.Settings
{
    public class ConnectionStrings
    {
        public string UserAppDb { get; set; }
    }

    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string AllowedHosts { get; set; }
    }
}
