namespace NetCoreAngular.Api.Config
{
    public class AuthSettings
    {
        public string Secret { get; set; }
        public int ExpiresMinute { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}