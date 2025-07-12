using chatbot.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbot.Data
{
    public class ChatbotDbContext : DbContext
    {
        public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                // USER
                modelBuilder.Entity<User>()
                    .HasKey(u => u.Id);

                modelBuilder.Entity<User>()
                    .Property(u => u.Id)
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity<User>()
                    .HasIndex(u => u.Username)
                    .IsUnique();

                // MESSAGE
                modelBuilder.Entity<Message>()
                    .HasKey(m => m.Id);

                modelBuilder.Entity<Message>()
                    .Property(m => m.Id)
                    .ValueGeneratedOnAdd();

                modelBuilder.Entity<Message>()
                    .Property(m => m.Timestamp)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                modelBuilder.Entity<Message>()
                    .HasOne(m => m.User)
                    .WithMany(u => u.Messages)
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
