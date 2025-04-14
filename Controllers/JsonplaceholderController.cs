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
        private readonly ILogger<JsonplaceholderController> _logger;

        public JsonplaceholderController(
            IHttpClientFactory httpClientFactory,
            IApiUrlResolver apiUrlResolver,
            ILogger<JsonplaceholderController> logger)
        {
            _apiUrlResolver = apiUrlResolver;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("{pathKey}")]
        public async Task<IActionResult> GetTodos(string pathKey)
        {
            try
            {
                var url = _apiUrlResolver.Resolve(ApiNames.JsonPlaceHolder, pathKey);

                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(url);
                var jsonResult = await response.Content.ReadAsStringAsync();

                return Ok(jsonResult);
            }

            catch (Exception exception)
            {
                _logger.LogError(exception.StackTrace);

                var errorResponse = new
                {
                    Message = "An unexpected error has occurred. Please try again later."
                };

                return StatusCode(500, errorResponse);
            }
        }
    }
}
