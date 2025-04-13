namespace ApplicationSettingConfiguration.Domain
{
    public class ApiSettings
    {
        public int GlobalTimeout { get; set; } = 30;
        public Dictionary<string, ApiEndpointSettings> Apis { get; set; } = new();
    }

    public class ApiEndpointSettings
    {
        public string? BaseUrl { get; set; }
        public Dictionary<string, string> Paths { get; set; } = new();
        public Dictionary<string, string> AdditionalSettings { get; set; } = new(); // To store extra settings
    }
}
