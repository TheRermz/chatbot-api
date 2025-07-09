using chatbot.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Data
{
    public class ChatbotDbContext : DbContext
    {
        public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.User).IsRequired();
                entity.Property(m => m.Text).IsRequired();
                entity.Property(m => m.Origin).IsRequired();
                entity.Property(m => m.Intent);
                entity.Property(m => m.Timestamp).HasDefaultValueSql("NOW()");
            });
        }
    }
}
