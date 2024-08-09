
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlazorAppCarousel.Services;

public class BannerService : IBannerService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BannerService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<string>> GetBanners()
    {
        var result = new List<string>();

        using (var httpClient = _httpClientFactory.CreateClient())
        {
            var jsonString = await httpClient.GetStringAsync("https://raw.githubusercontent.com/brrj/BlazorAppCarousel/master/banners.json");

            if (!string.IsNullOrEmpty(jsonString))
            {
                var items = JsonNode.Parse(jsonString)?.AsObject()["items"];

                if (items != null)
                    result = (JsonSerializer.Deserialize<List<string>>(items) ?? new());
            }
        }

        return result;
    }
}
