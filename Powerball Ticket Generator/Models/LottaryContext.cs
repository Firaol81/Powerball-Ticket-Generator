using Microsoft.EntityFrameworkCore;

namespace Powerball_Ticket_Generator.Models
{
    public class LottaryContext : DbContext
    {
        public LottaryContext(DbContextOptions<LottaryContext> options)
            : base(options)
        {
        }

        public DbSet<Lottary> Lottary { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lottary>().HasData(
                new Lottary
                {
                    Id = 1,
                    FullName = "John Doe",
                    Gender = "Male",
                    Age = 30,
                    Location = "New York",
                    PowerballNumbers = "1 2 3 4 5 PB: 6"
                },
                new Lottary
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Gender = "Female",
                    Age = 28,
                    Location = "Los Angeles",
                    PowerballNumbers = "7 8 9 10 11 PB: 12"
                }
                // Add more initial Lottary records here
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "L1", Name = "Lottery Genre 1" },
                new Genre { GenreId = "L2", Name = "Lottery Genre 2" }
                // Add more initial lottery-related genres here
            );
        }
    }
}
