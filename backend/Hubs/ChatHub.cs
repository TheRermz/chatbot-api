using AutoMapper;
using chatbot.DTOs.Message;
using chatbot.Models;
using chatbot.Services;
using Microsoft.AspNetCore.SignalR;

namespace chatbot.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly ChatFlowService _chatFlow;

        public ChatHub(IMapper mapper, ChatFlowService chatFlow)
        {
            _mapper = mapper;
            _chatFlow = chatFlow;
        }

        public async Task SendMessage(MessageDto dto)
        {
            var userMessage = _mapper.Map<Message>(dto);

            await Clients.All.SendAsync("ReceiveMessage", userMessage);

            var botMessage = _chatFlow.GenerateBotResponse(userMessage.User, userMessage.Text);

            await Clients.All.SendAsync("ReceiveMessage", botMessage);
        }
    }
}
