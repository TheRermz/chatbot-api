using AutoMapper;
using chatbot.DTOs.Message;
using chatbot.Models;
using chatbot.Services;
using chatbot.Data;
using Microsoft.AspNetCore.SignalR;

namespace chatbot.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly ChatFlowService _chatFlow;
        private readonly ChatbotDbContext _db;

        public ChatHub(IMapper mapper, ChatFlowService chatFlow, ChatbotDbContext db)
        {
            _mapper = mapper;
            _chatFlow = chatFlow;
            _db = db;
        }

        public async Task SendMessage(MessageDto dto)
        {
            var userMessage = _mapper.Map<Message>(dto);

            // Salva a mensagem do usuário
            _db.Messages.Add(userMessage);
            await _db.SaveChangesAsync();

            // Envia para quem estiver ouvindo
            await Clients.All.SendAsync("ReceiveMessage", userMessage);

            // Gera resposta do bot
            var botMessage = _chatFlow.GenerateBotResponse(userMessage.User, userMessage.Text);

            // Salva e envia mensagem do bot
            _db.Messages.Add(botMessage);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", botMessage);
        }
    }
}
