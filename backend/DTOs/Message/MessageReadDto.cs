using System;

namespace chatbot.DTOs.Message
{
    public class MessageReadDto
    {
        public Guid Id { get; set; }
        public string User { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public string Origin { get; set; } = "user";
        public string Intent { get; set; } = "unknown";
    }
}
