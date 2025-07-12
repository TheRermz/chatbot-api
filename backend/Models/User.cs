namespace chatbot.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }

        // Navegação (1 user p/ muitas mensagens)
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
