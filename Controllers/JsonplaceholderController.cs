using Microsoft.AspNetCore.Mvc;

namespace ApplicationSettingConfiguration.Controllers
{
    [Route("api/jsonplaceholder")]
    [ApiController]
    public class JsonplaceholderController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public JsonplaceholderController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{path}")]
        public async Task<IActionResult> GetTodos(string path)
        {
            var jsonPlaceHolderAPISetting = _configuration.GetSection("ApiConfiguration:jsonplaceholder");
            var baseUrl = jsonPlaceHolderAPISetting["baseUrl"];

            var apiPath = jsonPlaceHolderAPISetting.GetValue<string>($"path:{path}");
            var url = $"{baseUrl}/{apiPath}";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            var jsonResult = await response.Content.ReadAsStringAsync();

            return Ok(jsonResult);
        }
    }
}
