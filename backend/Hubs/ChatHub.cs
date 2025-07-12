using AutoMapper;
using chatbot.DTOs.Message;
using chatbot.Models;
using chatbot.Services;
using chatbot.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
            // Busca ou cria o usuário
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null)
            {
                user = new User { Username = dto.Username };
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }

            // Cria a mensagem do usuário
            var userMessage = new Message
            {
                User = user,
                UserId = user.Id,
                Text = dto.Text,
                Origin = "user"
            };

            _db.Messages.Add(userMessage);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", userMessage);

            // Gera a resposta do bot
            var botMessage = _chatFlow.GenerateBotResponse(user, dto.Text);

            _db.Messages.Add(botMessage);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", botMessage);
        }

    }
}
