namespace ConsumeDogAPI.Services;

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DogApiService
{
    private readonly HttpClient _httpClient;

    public DogApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetTerrierSubBreed()
    {
        var response = await _httpClient.GetAsync("https://dog.ceo/api/breed/terrier/list");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<DogApiResponse>(jsonResponse);

        return data?.subBreed ?? new List<string>();
    }

    private class DogApiResponse
    {
        public List<string> subBreed { get; set; }
        public string Status { get; set; }
    }
}
