using AutoMapper;
using chatbot.Data;
using chatbot.DTOs.Message;
using chatbot.Models;
using chatbot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ChatFlowService _chatFlow;
        private readonly ChatbotDbContext _context;

        public MessagesController(IMapper mapper, ChatFlowService chatFlow, ChatbotDbContext context)
        {
            _mapper = mapper;
            _chatFlow = chatFlow;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            var messages = await _context.Messages
            .OrderBy(m => m.Timestamp)
            .ToListAsync();

            var messagesDto = _mapper.Map<List<MessageReadDto>>(messages);

            return Ok(messages);
        }

        [HttpPost]
        public ActionResult<Message> Post([FromBody] MessageDto dto)
        {
            var userMessage = _mapper.Map<Message>(dto);
            var botResponse = _chatFlow.GenerateBotResponse(userMessage.User, userMessage.Text);
            return Ok(botResponse);
        }
    }
}
