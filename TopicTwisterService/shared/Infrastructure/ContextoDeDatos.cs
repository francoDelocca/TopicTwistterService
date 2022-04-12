using Microsoft.EntityFrameworkCore;
using TopicTwisterService.Player.Domain;


public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(entity => {
             entity.HasIndex(e => e.PlayerId).IsUnique();
            });
        }

        public DbSet<Player> Players { get; set; }        
        public DbSet<Word> Words { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Round> Rounds { get; set; }        
        public DbSet<Match> Matches { get; set; }       
        public DbSet<WordsEnteredByPlayer> WordsEnteredByPlayer { get; set; }
        public DbSet<Notification> Notifications { get; set; }
}

