namespace ApplicationSettingConfiguration.Domain
{
    /// <summary>
    /// Represents the root configuration for external APIs.
    /// </summary>
    public class ApiSettings
    {
        public int GlobalTimeout { get; init; } = 30;

        // <summary>
        /// Retreive the collection of configured APIs, keyed by their name.
        /// </summary>
        public IReadOnlyDictionary<string, ApiEndpointSettings> Apis { get; init; } = new Dictionary<string, ApiEndpointSettings>();
    }

    /// <summary>
    /// Represents configuration details for a single external API.
    /// </summary>
    public class ApiEndpointSettings
    {
        /// <summary>
        /// Gets the base URL of the API (e.g., "https://jsonplaceholder.typicode.com").
        /// </summary>
        public string? BaseUrl { get; init; }

        /// <summary>
        /// Gets the collection of endpoint path templates, keyed by name (e.g., "todos" -> "todos").
        /// </summary>
        public IReadOnlyDictionary<string, string> Paths { get; init; } = new Dictionary<string, string>();
        public IReadOnlyDictionary<string, string> AdditionalSettings { get; init; } = new Dictionary<string, string>();
    }
}
