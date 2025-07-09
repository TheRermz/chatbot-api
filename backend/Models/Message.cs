using System;

namespace chatbot.Models
{
    public class Message
    {
        public int Id { get; set; }
        public required string User { get; set; }
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Origin { get; set; } = "user";
        public string Intent { get; set; } = "unknown";
    }
}
