using ApplicationSettingConfiguration.Domain;

namespace ApplicationSettingConfiguration.Service
{
    public interface IApiUrlResolver
    {
        string? Resolve(string apiName, string path);
    }

    public class ApiUrlResolver : IApiUrlResolver
    {
        private readonly ApiSettings _apiSettings;

        public ApiUrlResolver(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public string Resolve(string apiName, string path)
        {
            if (!_apiSettings.Apis.TryGetValue(apiName, out var apiConfiguration))
            {
                throw new ArgumentException($"API '{apiName}' not found.");
            }

            if (!apiConfiguration.Paths.TryGetValue(path, out var apiPath))
            {
                throw new KeyNotFoundException($"Path '{path}' not found in API '{apiName}'.");
            }

            return $"{apiConfiguration.BaseUrl}/{apiPath}";
        }
    }
}
