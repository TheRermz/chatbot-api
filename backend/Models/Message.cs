using System;

namespace chatbot.Models
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Origin { get; set; } = "user";
        public string Intent { get; set; } = "unknown";

        //Relacionamento com usuário
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
