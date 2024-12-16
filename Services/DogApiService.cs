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

        return data?.message ?? new List<string>();
    }

    /*
    public List<string> SortByLengthBubbleSort(List<string> subBreeds)
    {
        for (int i = 0; i < subBreeds.Count - 1; i++)
        {
            for (int j = 0; j < subBreeds.Count - i - 1; j++)
            {
                if (subBreeds[j].Length > subBreeds[j + 1].Length)
                {
                    var temp = subBreeds[j];
                    subBreeds[j] = subBreeds[j + 1];
                    subBreeds[j + 1] = temp;
                }
            }
        }
        return subBreeds;
    }

    */

    public List<string> SortAlphabeticallyAndByLength(List<string> subBreeds)
    {
        return subBreeds
            .OrderBy(name => name)
            .ThenBy(name => name.Length)
            .ToList();
    }

    private class DogApiResponse
    {
        public List<string> message { get; set; }
        public string Status { get; set; }
    }
}
