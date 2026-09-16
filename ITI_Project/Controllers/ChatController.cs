using AspNetCoreGeneratedDocument;
using ITI_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using OpenAI.Realtime;
using System.Text.Json;
using ITI_Project.Model;

namespace ITI_Project.Controllers
{
    public class ChatController(IChatClient chatClient, LibraryTool libraryTool) : Controller
    {
        private const string HistoryKey = "library-chat-history";
        private const string SystemPrompt = """
            You are the smart assistant for ITI Library.
            Answer member queries about books, loans, and reservations using the provided tools.
            Never invent book availability, loan details, or make reservations without calling the tools.
            Always respond politely and keep responses clear and concise.
            """;

        [HttpGet]
        public IActionResult Index()
        {
            var history = LoadHistory();
            return View(history);
        }

        [HttpPost]
        public async Task<IActionResult> Send (string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return RedirectToAction(nameof(Index));

            var history = LoadHistory();
            int currentMemberId = HttpContext.Session.GetInt32("MemberId") ?? 1;

            var messages = new List<ChatMessage> { new(ChatRole.System, SystemPrompt) };
            foreach(var turn in history)
            {
                messages.Add(new ChatMessage(
                    turn.Role == "user" ? ChatRole.User : ChatRole.Assistant,
                    turn.Text));
            }

            messages.Add(new ChatMessage(ChatRole.User, message));
            history.Add(new ChatTurn { Role = "user", Text = message });

            var options = new ChatOptions
            {
                MaxOutputTokens = 500,
                Tools =
                [
                    AIFunctionFactory.Create(libraryTool.GetBookDetails),
                    AIFunctionFactory.Create(libraryTool.GetBooksByAuthor),
                    AIFunctionFactory.Create(libraryTool.ListBooksByCategory),

                    AIFunctionFactory.Create(libraryTool.SearchBooks),
                    AIFunctionFactory.Create(() => 
                        libraryTool.GetMyLoans(currentMemberId), 
                        nameof(libraryTool.GetMyLoans),
                        "Get active loans" ),

                    AIFunctionFactory.Create((string title) =>
                        libraryTool.ReserveBook(title, currentMemberId),
                        nameof(libraryTool.ReserveBook),
                         "Reserve a book"),
                ]
            };

            string answer;
            try
            {
                var response = await chatClient.GetResponseAsync(messages, options);
                answer = response.Text ?? "No response generated";
            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
                answer = "Sorry, an error occurred while processing your request.";
            }

            history.Add(new ChatTurn { Role = "assistant", Text= answer});
            SaveHistory(history);

            return RedirectToAction(nameof(Index));

        }

        private List<ChatTurn> LoadHistory()
        {
            var saved = HttpContext.Session.GetString(HistoryKey);
            if (string.IsNullOrEmpty(saved))
            {
                return new List<ChatTurn>();
            }

            return JsonSerializer.Deserialize<List<ChatTurn>>(saved) ?? new List<ChatTurn>();
        }

        [HttpPost]
        public IActionResult Reset()
        {
            HttpContext.Session.Remove(HistoryKey);
            return RedirectToAction(nameof(Index));
        }


        private void SaveHistory (List<ChatTurn> history)
            => HttpContext.Session.SetString(HistoryKey, JsonSerializer.Serialize(history));
        

        public class ChatTurn
        {
            public string Role { get; set; } = "";
            public string Text { get; set; } = "";
            public string? ToolCallDetails { get; set; }
        }

    }
}
