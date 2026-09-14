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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming" },
                new Category { Id = 2, Name = "Science" },
                new Category { Id = 3, Name = "History" },
                new Category { Id = 4, Name = "Literature" },
                new Category { Id = 5, Name = "Self Development" },
                new Category { Id = 6, Name = "Business" },
                new Category { Id = 7, Name = "Fantasy" },
                new Category { Id = 8, Name = "Mystery" },
                new Category { Id = 9, Name = "Psychology" },
                new Category { Id = 10, Name = "Travel" },
                new Category { Id = 11, Name = "Biography" },
                new Category { Id = 12, Name = "Romance" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Naguib Mahfouz", Bio = "Egyptian Nobel Prize winning novelist.", Photo = "" },
                new Author { Id = 2, Name = "Gabriel Garcia Marquez", Bio = "Colombian novelist and magical realism pioneer.", Photo = "" },
                new Author { Id = 3, Name = "Carlos Ruiz Zafon", Bio = "Spanish novelist known for literary mysteries.", Photo = "" },
                new Author { Id = 4, Name = "Ahlam Mosteghanemi", Bio = "Algerian novelist and poet.", Photo = "" },
                new Author { Id = 5, Name = "Ihsan Abdel Quddous", Bio = "Egyptian journalist and novelist.", Photo = "" },
                new Author { Id = 6, Name = "Agatha Christie", Bio = "English mystery novelist.", Photo = "" },
                new Author { Id = 7, Name = "James Clear", Bio = "Writer focused on habits and behavior.", Photo = "" },
                new Author { Id = 8, Name = "Neil Gaiman", Bio = "English fantasy writer.", Photo = "" },
                new Author { Id = 9, Name = "Yuval Noah Harari", Bio = "Historian and writer.", Photo = "" },
                new Author { Id = 10, Name = "Paulo Coelho", Bio = "Brazilian novelist.", Photo = "" },
                new Author { Id = 11, Name = "Jane Austen", Bio = "English novelist.", Photo = "" },
                new Author { Id = 12, Name = "Arthur Conan Doyle", Bio = "British mystery writer.", Photo = "" }
            );

            var titles = new[]
            {
                "Midaq Alley",
                "Palace Walk",
                "Palace of Desire",
                "Sugar Street",
                "The Thief and the Dogs",
                "Miramar",
                "One Hundred Years of Solitude",
                "Love in the Time of Cholera",
                "Chronicle of a Death Foretold",
                "The Autumn of the Patriarch",
                "No One Writes to the Colonel",
                "The Shadow of the Wind",
                "The Angel's Game",
                "The Prisoner of Heaven",
                "The Labyrinth of the Spirits",
                "Memory in the Flesh",
                "Chaos of the Senses",
                "Passer of Beds",
                "Black Suits You",
                "I Am Free",
                "Murder on the Orient Express",
                "And Then There Were None",
                "Atomic Habits",
                "American Gods",
                "Sapiens",
                "The Alchemist",
                "Pride and Prejudice",
                "Sherlock Holmes",
                "The Lost Library",
                "Morning in Alexandria",
                "Beyond the Dunes",
                "The Midnight Archive",
                "River Without Maps",
                "The Small Observatory",
                "Silent Equations",
                "A Map of Stars",
                "The Paper Garden",
                "City of Jasmine",
                "Northern Lights",
                "Desert Letters"
            };

            var books = new List<Book>();

            for (int id = 1; id <= titles.Length; id++)
            {
                books.Add(new Book
                {
                    Id = id,
                    Title = titles[id - 1],
                    ISBN = $"9780000000{id:D3}",
                    Summary = $"A complete test summary for {titles[id - 1]}.",
                    BookLanguage = id % 3 == 0 ? "Arabic" : "English",
                    PublishedYear = 1980 + id,
                    CoverImage = "",
                    AuthorId = ((id - 1) % 12) + 1,
                    CategoryId = ((id - 1) % 12) + 1
                });
            }

            modelBuilder.Entity<Book>().HasData(books);

            var members = new List<Member>
            {
                new Member
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@library.local",
                    PhoneNumber = "01000000001",
                    PasswordHash = "Admin@123",
                    Role = Role.Admin,
                    MembershipStartDate = new DateTime(2024, 1, 1),
                    MembershipExpiryDate = new DateTime(2030, 1, 1),
                    IsBlocked = false
                },
                new Member
                {
                    Id = 2,
                    UserName = "sara.librarian",
                    Email = "sara.librarian@library.local",
                    PhoneNumber = "01000000002",
                    PasswordHash = "Librarian@123",
                    Role = Role.Librarian,
                    MembershipStartDate = new DateTime(2024, 1, 1),
                    MembershipExpiryDate = new DateTime(2030, 1, 1),
                    IsBlocked = false
                },
                new Member
                {
                    Id = 3,
                    UserName = "omar.librarian",
                    Email = "omar.librarian@library.local",
                    PhoneNumber = "01000000003",
                    PasswordHash = "Librarian@123",
                    Role = Role.Librarian,
                    MembershipStartDate = new DateTime(2024, 1, 1),
                    MembershipExpiryDate = new DateTime(2030, 1, 1),
                    IsBlocked = false
                }
            };

            for (int id = 4; id <= 40; id++)
            {
                members.Add(new Member
                {
                    Id = id,
                    UserName = $"member{id:D2}",
                    Email = $"member{id:D2}@library.local",
                    PhoneNumber = $"0103{id:D7}",
                    PasswordHash = "Member@123",
                    Role = Role.Member,
                    MembershipStartDate = new DateTime(2026, 1, 1),
                    MembershipExpiryDate = new DateTime(2027, 12, 31),
                    IsBlocked = false
                });
            }

            var expiredMember = members.First(m => m.Id == 38);
            expiredMember.UserName = "expired.member";
            expiredMember.Email = "expired.member@library.local";
            expiredMember.MembershipExpiryDate = new DateTime(2025, 1, 1);

            var blockedMember = members.First(m => m.Id == 39);
            blockedMember.UserName = "blocked.member";
            blockedMember.Email = "blocked.member@library.local";
            blockedMember.IsBlocked = true;

            var testMember = members.First(m => m.Id == 40);
            testMember.UserName = "test.member";
            testMember.Email = "test.member@library.local";
            testMember.PasswordHash = "Test@123";

            modelBuilder.Entity<Member>().HasData(members);

            var loans = new List<Loan>
            {
                new Loan { Id = 1, BookCopyId = 1, MemberId = 4, RequestDate = new DateTime(2026, 8, 1), BorrowDate = new DateTime(2026, 8, 1), DueDate = new DateTime(2026, 8, 15), Status = LoanStatus.Active },
                new Loan { Id = 2, BookCopyId = 3, MemberId = 5, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 28), Status = LoanStatus.Active },
                new Loan { Id = 3, BookCopyId = 5, MemberId = 6, RequestDate = new DateTime(2026, 9, 10), Status = LoanStatus.Requested },
                new Loan { Id = 4, BookCopyId = 7, MemberId = 7, RequestDate = new DateTime(2026, 8, 25), BorrowDate = new DateTime(2026, 8, 25), DueDate = new DateTime(2026, 9, 8), Status = LoanStatus.ReturnRequested },
                new Loan { Id = 5, BookCopyId = 9, MemberId = 8, RequestDate = new DateTime(2026, 6, 1), BorrowDate = new DateTime(2026, 6, 1), DueDate = new DateTime(2026, 6, 15), ReturnDate = new DateTime(2026, 6, 21), Status = LoanStatus.Returned },
                new Loan { Id = 6, BookCopyId = 11, MemberId = 9, RequestDate = new DateTime(2026, 8, 1), BorrowDate = new DateTime(2026, 8, 1), DueDate = new DateTime(2026, 8, 30), ReturnDate = new DateTime(2026, 9, 10), Status = LoanStatus.Returned },
                new Loan { Id = 7, BookCopyId = 13, MemberId = 10, RequestDate = new DateTime(2026, 8, 20), Status = LoanStatus.Rejected, RejectionReason = "Membership verification is required." },
                new Loan { Id = 8, BookCopyId = 15, MemberId = 11, RequestDate = new DateTime(2026, 8, 22), Status = LoanStatus.Cancelled },
                new Loan { Id = 9, BookCopyId = 17, MemberId = 12, RequestDate = new DateTime(2026, 9, 2), BorrowDate = new DateTime(2026, 9, 2), DueDate = new DateTime(2026, 9, 20), Status = LoanStatus.Active },
                new Loan { Id = 10, BookCopyId = 19, MemberId = 13, RequestDate = new DateTime(2026, 9, 5), BorrowDate = new DateTime(2026, 9, 5), DueDate = new DateTime(2026, 10, 5), Status = LoanStatus.Active },
                new Loan { Id = 11, BookCopyId = 21, MemberId = 14, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 14), Status = LoanStatus.Active },
                new Loan { Id = 12, BookCopyId = 23, MemberId = 39, RequestDate = new DateTime(2026, 8, 1), BorrowDate = new DateTime(2026, 8, 1), DueDate = new DateTime(2026, 8, 10), Status = LoanStatus.Active },
                new Loan { Id = 13, BookCopyId = 25, MemberId = 15, RequestDate = new DateTime(2026, 7, 1), BorrowDate = new DateTime(2026, 7, 1), DueDate = new DateTime(2026, 7, 15), ReturnDate = new DateTime(2026, 7, 14), Status = LoanStatus.Returned },
                new Loan { Id = 14, BookCopyId = 27, MemberId = 16, RequestDate = new DateTime(2026, 9, 12), Status = LoanStatus.Requested },
                new Loan { Id = 15, BookCopyId = 29, MemberId = 17, RequestDate = new DateTime(2026, 8, 20), BorrowDate = new DateTime(2026, 8, 20), DueDate = new DateTime(2026, 9, 3), Status = LoanStatus.ReturnRequested },
                new Loan { Id = 16, BookCopyId = 31, MemberId = 18, RequestDate = new DateTime(2026, 9, 3), BorrowDate = new DateTime(2026, 9, 3), DueDate = new DateTime(2026, 9, 25), Status = LoanStatus.Active },
                new Loan { Id = 17, BookCopyId = 33, MemberId = 19, RequestDate = new DateTime(2026, 9, 4), BorrowDate = new DateTime(2026, 9, 4), DueDate = new DateTime(2026, 9, 26), Status = LoanStatus.Active },
                new Loan { Id = 18, BookCopyId = 35, MemberId = 20, RequestDate = new DateTime(2026, 8, 15), BorrowDate = new DateTime(2026, 8, 15), DueDate = new DateTime(2026, 9, 1), Status = LoanStatus.Active },
                new Loan { Id = 19, BookCopyId = 36, MemberId = 21, RequestDate = new DateTime(2026, 8, 20), BorrowDate = new DateTime(2026, 8, 20), DueDate = new DateTime(2026, 9, 5), Status = LoanStatus.Active },
                new Loan { Id = 20, BookCopyId = 37, MemberId = 22, RequestDate = new DateTime(2026, 8, 25), BorrowDate = new DateTime(2026, 8, 25), DueDate = new DateTime(2026, 9, 9), Status = LoanStatus.Active },
                new Loan { Id = 21, BookCopyId = 38, MemberId = 23, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 30), Status = LoanStatus.Active },
                new Loan { Id = 22, BookCopyId = 39, MemberId = 24, RequestDate = new DateTime(2026, 8, 20), BorrowDate = new DateTime(2026, 8, 20), DueDate = new DateTime(2026, 9, 4), Status = LoanStatus.Active },
                new Loan { Id = 23, BookCopyId = 40, MemberId = 25, RequestDate = new DateTime(2026, 8, 22), BorrowDate = new DateTime(2026, 8, 22), DueDate = new DateTime(2026, 9, 6), Status = LoanStatus.Active },
                new Loan { Id = 24, BookCopyId = 41, MemberId = 26, RequestDate = new DateTime(2026, 8, 25), BorrowDate = new DateTime(2026, 8, 25), DueDate = new DateTime(2026, 9, 8), Status = LoanStatus.Active },
                new Loan { Id = 25, BookCopyId = 42, MemberId = 27, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 15), Status = LoanStatus.Active },
                new Loan { Id = 26, BookCopyId = 43, MemberId = 28, RequestDate = new DateTime(2026, 9, 2), BorrowDate = new DateTime(2026, 9, 2), DueDate = new DateTime(2026, 9, 16), Status = LoanStatus.Active },
                new Loan { Id = 27, BookCopyId = 44, MemberId = 29, RequestDate = new DateTime(2026, 8, 15), BorrowDate = new DateTime(2026, 8, 15), DueDate = new DateTime(2026, 8, 29), Status = LoanStatus.Active },
                new Loan { Id = 28, BookCopyId = 45, MemberId = 30, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 20), Status = LoanStatus.Active },
                new Loan { Id = 29, BookCopyId = 47, MemberId = 31, RequestDate = new DateTime(2026, 9, 10), Status = LoanStatus.Requested },
                new Loan { Id = 30, BookCopyId = 49, MemberId = 32, RequestDate = new DateTime(2026, 9, 3), BorrowDate = new DateTime(2026, 9, 3), DueDate = new DateTime(2026, 9, 17), Status = LoanStatus.Active }
            };

            modelBuilder.Entity<Loan>().HasData(loans);

            var copies = new List<BookCopy>();

            for (int bookId = 1; bookId <= 40; bookId++)
            {
                var firstCopyId = (bookId - 1) * 2 + 1;
                var secondCopyId = firstCopyId + 1;

                copies.Add(new BookCopy
                {
                    Id = firstCopyId,
                    Barcode = $"BC-{firstCopyId:D4}",
                    BookId = bookId,
                    Status = BookCopyStatus.Available
                });

                copies.Add(new BookCopy
                {
                    Id = secondCopyId,
                    Barcode = $"BC-{secondCopyId:D4}",
                    BookId = bookId,
                    Status = BookCopyStatus.Available
                });
            }

            foreach (var loan in loans)
            {
                var copy = copies.First(c => c.Id == loan.BookCopyId);

                copy.Status = loan.Status switch
                {
                    LoanStatus.Requested => BookCopyStatus.Reserved,
                    LoanStatus.Active => BookCopyStatus.Borrowed,
                    LoanStatus.ReturnRequested => BookCopyStatus.Borrowed,
                    _ => BookCopyStatus.Available
                };
            }

            modelBuilder.Entity<BookCopy>().HasData(copies);

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, BookId = 20, MemberId = 24, ReservationDate = new DateTime(2026, 9, 10, 9, 0, 0), Status = "Pending" },
                new Reservation { Id = 2, BookId = 20, MemberId = 25, ReservationDate = new DateTime(2026, 9, 10, 10, 0, 0), Status = "Pending" },
                new Reservation { Id = 3, BookId = 20, MemberId = 26, ReservationDate = new DateTime(2026, 9, 10, 11, 0, 0), Status = "Cancelled" },
                new Reservation { Id = 4, BookId = 21, MemberId = 27, ReservationDate = new DateTime(2026, 9, 11, 9, 0, 0), Status = "Pending" },
                new Reservation { Id = 5, BookId = 21, MemberId = 28, ReservationDate = new DateTime(2026, 9, 11, 10, 0, 0), Status = "Pending" },
                new Reservation { Id = 6, BookId = 24, MemberId = 29, ReservationDate = new DateTime(2026, 9, 12, 9, 0, 0), Status = "Pending" },
                new Reservation { Id = 7, BookId = 24, MemberId = 30, ReservationDate = new DateTime(2026, 9, 12, 10, 0, 0), Status = "Pending" },
                new Reservation { Id = 8, BookId = 25, MemberId = 31, ReservationDate = new DateTime(2026, 9, 12, 11, 0, 0), Status = "Pending" },
                new Reservation { Id = 9, BookId = 26, MemberId = 32, ReservationDate = new DateTime(2026, 9, 13, 9, 0, 0), Status = "Fulfilled" },
                new Reservation { Id = 10, BookId = 27, MemberId = 33, ReservationDate = new DateTime(2026, 9, 13, 10, 0, 0), Status = "Cancelled" }
            );

            modelBuilder.Entity<Fine>().HasData(
                new Fine { Id = 1, LoanId = 5, Amount = 30m, CreatedDate = new DateTime(2026, 6, 21), IsPaid = true },
                new Fine { Id = 2, LoanId = 6, Amount = 55m, CreatedDate = new DateTime(2026, 9, 10), IsPaid = false }
            );

            var reviews = new List<Review>();

            for (int id = 1; id <= 30; id++)
            {
                reviews.Add(new Review
                {
                    Id = id,
                    BookId = id,
                    MemberId = id + 3,
                    Rating = ((id - 1) % 5) + 1,
                    Comment = $"Test review number {id} for book {id}.",
                    CreatedDate = new DateTime(2026, 1, 1).AddDays(id * 6)
                });
            }

            modelBuilder.Entity<Review>().HasData(reviews);
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