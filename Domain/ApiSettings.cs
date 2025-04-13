namespace ApplicationSettingConfiguration.Domain
{
    public class ApiSettings
    {
        public int GlobalTimeout { get; init; } = 30;
        public IReadOnlyDictionary<string, ApiEndpointSettings> Apis { get; init; } = new Dictionary<string, ApiEndpointSettings>();
    }

    public class ApiEndpointSettings
    {
        public string? BaseUrl { get; init; }
        public IReadOnlyDictionary<string, string> Paths { get; init; } = new Dictionary<string, string>();
        public IReadOnlyDictionary<string, string> AdditionalSettings { get; init; } = new Dictionary<string, string>();
    }
}
