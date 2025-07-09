// Services/ChatFlowService.cs
using chatbot.Models;

namespace chatbot.Services
{
    public class ChatFlowService
    {
        public Message GenerateBotResponse(string user, string userMessage)
        {
            var intent = GetIntent(userMessage.ToLowerInvariant());
            var response = GetResponseForIntent(intent);

            return new Message
            {
                User = "Bot",
                Text = response,
                Origin = "bot",
                Intent = intent
            };
        }

        private string GetIntent(string text)
        {
            if (text.Contains("pasta")) return "acesso_pasta";
            if (text.Contains("sistema")) return "problema_sistema";
            if (text.Contains("suporte")) return "redirecionar_suporte";
            return "unknown";
        }

        private string GetResponseForIntent(string intent)
        {
            return intent switch
            {
                "acesso_pasta" => "Para solicitar acesso a pastas, acesse o Intranet > Solicitações > Acesso a pasta.",
                "problema_sistema" => "Qual sistema você está tentando acessar?",
                "redirecionar_suporte" => "Estou redirecionando você para o suporte.",
                _ => "Desculpe, não entendi sua solicitação. Pode reformular?"
            };
        }
    }
}
