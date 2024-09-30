using KcbBotSemanticKernel.Bot.Common;
using KcbBotSemanticKernel.Bot.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using KcbBotSemanticKernel.Bot.Models.Chat;

namespace KcbBotSemanticKernel.Bot.Helper
{
    public class ApiHelper
    {
        private readonly ConfigHelper _configHelper;

        public ApiHelper(ConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        public async Task<string> ChatAsync(string question)
        {
            try
            {
                ApiSettings apiSettings = _configHelper.GetApiSettings();
                string apiUrl = $"{apiSettings.BaseUrl}{apiSettings.MessageEndpoing}";

                var payload = new QueryMessage()
                {
                    ChatId = string.Empty,
                    Question = question,
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (HttpClient _httpClient = new HttpClient())
                {
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(apiSettings.Key))
                    {
                        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiSettings.Key);
                    }

                    var response = _httpClient.PostAsync(apiUrl, content).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {response.StatusCode} - {responseContent}");
                        return $"Error: {response.StatusCode} - {responseContent}";
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Request error: {httpEx.Message}");
                return "Request error occurred.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return "Something went wrong!";
            }
        }
    }
}
