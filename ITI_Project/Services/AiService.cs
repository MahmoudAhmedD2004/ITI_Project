using ITI_Project.ModelView;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Text.Json;

namespace ITI_Project.Services
{
    public class AiService : IAiService
    {
        private readonly IConfiguration _config;

        public AiService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<BookAutoSummaryDto> GenerateBookSummaryAsync(string backCoverText, List<string> availableCategories)
        {
            var baseUrl = _config["AI:BaseUrl"] ?? "https://openrouter.ai/api/v1";
            var apiKey = _config["AI:ApiKey"];
            var model = _config["AI:Model"] ?? "google/gemini-2.5-flash-lite";

            if (string.IsNullOrEmpty(apiKey))
                throw new Exception("OpenRouter API Key is missing in appsettings.json");

            var options = new OpenAIClientOptions { Endpoint = new Uri(baseUrl) };
            var client = new ChatClient(model, new ApiKeyCredential(apiKey), options);

            var categoriesList = string.Join(", ", availableCategories);

            var prompt = $@"
            You are a library assistant. Analyze the text from the book's back cover below:
            ""{backCoverText}""

            Extract the following output strictly in valid JSON format with no extra markdown formatting or conversational text:
            - summary: A concise summary of the back cover in 4 lines in English.
            - category: You MUST choose exactly one value from this fixed list, with no other option allowed: [{categoriesList}]. Pick the closest match even if imperfect.
            - tags: A list of 3 to 5 key tags in English.

            Required JSON format:
            {{
              ""summary"": ""..."",
              ""category"": ""..."",
              ""tags"": [""tag1"", ""tag2"", ""tag3""]
            }}";

            var chatMessages = new List<ChatMessage>
    {
        new SystemChatMessage("You are a helpful assistant that strictly outputs JSON."),
        new UserChatMessage(prompt)
    };

            ChatCompletion completion = await client.CompleteChatAsync(chatMessages);
            string rawResponse = completion.Content[0].Text;

            string jsonContent = CleanJsonContent(rawResponse);

            var result = JsonSerializer.Deserialize<BookAutoSummaryDto>(
                jsonContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (result == null)
                throw new Exception("Failed to parse AI response.");

            
            if (!availableCategories.Contains(result.Category, StringComparer.OrdinalIgnoreCase))
            {
                result.Category = availableCategories.FirstOrDefault() ?? result.Category;
            }

            return result;
        }
        private string CleanJsonContent(string content)
        {
            content = content.Trim();

            if (content.StartsWith("```json"))
            {
                content = content.Substring(7);
            }
            else if (content.StartsWith("```"))
            {
                content = content.Substring(3);
            }

            if (content.EndsWith("```"))
            {
                content = content.Substring(0, content.Length - 3);
            }

            return content.Trim();
        }
    }
}
