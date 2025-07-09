using AutoMapper;
using chatbot.DTOs.Message;
using chatbot.Models;
using chatbot.Services;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ChatFlowService _chatFlow;

        public MessagesController(IMapper mapper, ChatFlowService chatFlow)
        {
            _mapper = mapper;
            _chatFlow = chatFlow;
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
