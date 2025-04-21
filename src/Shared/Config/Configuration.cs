namespace Shared.Config
{
    public class Configuration
    {
        public LoggingSettings Logging { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public JwtSettings Jwt { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class LoggingSettings
    {
        public LogLevelSettings LogLevel { get; set; }
    }

    public class LogLevelSettings
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
