// Services/ChatFlowService.cs
using chatbot.Models;

namespace chatbot.Services
{
    public class ChatFlowService
    {
        private readonly Dictionary<string, int> _errosSeguidos = new();

        public Message GenerateBotResponse(User user, string userMessage)
        {
            var intent = GetIntent(userMessage.ToLowerInvariant());

            // Se não entendeu a intenção
            if (intent == "unknown")
            {
                if (!_errosSeguidos.ContainsKey(user.Username))
                    _errosSeguidos[user.Username] = 0;

                _errosSeguidos[user.Username]++;

                if (_errosSeguidos[user.Username] >= 3)
                {
                    _errosSeguidos[user.Username] = 0; // zera contador

                    return new Message
                    {
                        User = user,
                        Text = "Encaminhando você para o suporte humano...",
                        Origin = "bot",
                        Intent = "redirecionar_suporte"
                    };
                }

                return new Message
                {
                    User = user,
                    Text = "Desculpe, não entendi sua solicitação. Pode reformular?",
                    Origin = "bot",
                    Intent = "unknown"
                };
            }

            // Se entendeu, zera contador
            _errosSeguidos[user.Username] = 0;

            return new Message
            {
                User = user,
                Text = GetResponseForIntent(intent),
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
