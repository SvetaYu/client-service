using System.Net.Http.Json;

namespace ClientComponent;

public class ClientComponent : IClientComponent
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ClientComponent(string baseUrl)
    {
        _baseUrl = baseUrl;
        var clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };
        _httpClient = new HttpClient(clientHandler);
    }

    public async Task<KeyValuePair?> Get(string key)
    {
        using var response = await _httpClient.GetAsync($"{_baseUrl}/get?key={key}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadFromJsonAsync<KeyValuePair>();
        return responseBody;
    }
    

    public async Task<KeyValuePair?> Set(string key, string value)
    {
        using var response = await _httpClient.PutAsJsonAsync(
            $"{_baseUrl}/set?key={key}&value={value}",
            new KeyValuePair(key, value));
        response.EnsureSuccessStatusCode();
        var pair = await response.Content.ReadFromJsonAsync<KeyValuePair>();
        return pair;
    }
}