using ITI_Project.Model;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming" },
                new Category { Id = 2, Name = "Science" },
                new Category { Id = 3, Name = "History" },
                new Category { Id = 4, Name = "Literature" },
                new Category { Id = 5, Name = "Self Development" },
                new Category { Id = 6, Name = "Business" },
                new Category { Id = 7, Name = "Fantasy" },
                new Category { Id = 8, Name = "Mystery" }
            );
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
