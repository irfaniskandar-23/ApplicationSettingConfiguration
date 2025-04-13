using ApplicationSettingConfiguration.Constant;
using ApplicationSettingConfiguration.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationSettingConfiguration.Controllers
{
    [Route("api/jsonplaceholder")]
    [ApiController]
    public class JsonplaceholderController : ControllerBase
    {
        private readonly IApiUrlResolver _apiUrlResolver;
        private readonly IHttpClientFactory _httpClientFactory;

        public JsonplaceholderController(IHttpClientFactory httpClientFactory, IApiUrlResolver apiUrlResolver)
        {
            _apiUrlResolver = apiUrlResolver;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{path}")]
        public async Task<IActionResult> GetTodos(string pathKey)
        {
            var url = _apiUrlResolver.Resolve(ApiNames.JsonPlaceHolder, pathKey);

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            var jsonResult = await response.Content.ReadAsStringAsync();

            return Ok(jsonResult);
        }
    }
}
