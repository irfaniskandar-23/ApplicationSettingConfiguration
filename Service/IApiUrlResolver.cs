using ApplicationSettingConfiguration.Domain;

namespace ApplicationSettingConfiguration.Service
{
    /// <summary>
    /// Resolves full API URLs based on the API name and path key.
    /// </summary>
    public interface IApiUrlResolver
    {
        /// <summary>
        /// Resolves the full URL for a given API name and path key.
        /// </summary>
        /// <param name="apiName">API name as defined in Environment Configuration</param>
        /// <param name="pathKey">Key for specific path in the API </param>
        /// <returns> Base Url + Path</returns>
        /// <exception cref="ArgumentException">Thrown if the API name is not found</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the path key is not found.</exception>
        string? Resolve(string apiName, string pathKey);
    }

    /// <summary>
    /// Default implementation of <see cref="IApiUrlResolver"/> that uses ApiSettings to resolve URLs.
    /// </summary>
    public class ApiUrlResolver : IApiUrlResolver
    {
        private readonly ApiSettings _apiSettings;

        public ApiUrlResolver(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public string Resolve(string apiName, string pathKey)
        {
            if (!_apiSettings.Apis.TryGetValue(apiName, out var apiConfg))
            {
                throw new ArgumentException($"API '{apiName}' not found.");
            }

            if (!apiConfg.Paths.TryGetValue(pathKey, out var relativePath))
            {
                throw new KeyNotFoundException($"Path '{pathKey}' not found in API '{apiName}'.");
            }

            return $"{apiConfg.BaseUrl}/{relativePath}";
        }
    }
}
