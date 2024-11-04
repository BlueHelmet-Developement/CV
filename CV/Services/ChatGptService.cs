
using System.Text.Json;

namespace CV.Services
{
    public class ChatGptService(HttpClient httpClient, string apiKey) : IChatGptService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = apiKey;

        public async Task<string> GetChatGPTResponseAsync(string prompt)
        {
            var requestUri = "https://api.openai.com/v1/chat/completions";

            var requestBody = new
            {
                model = "gpt-4o-mini-2024-07-18",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            request.Content = JsonContent.Create(requestBody);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"ChatGPT API request failed: {response.StatusCode}, {errorResponse}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var chatGPTResponse = JsonDocument.Parse(jsonResponse);
            var message = chatGPTResponse.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

            return message ?? "";
        }
    }
}
