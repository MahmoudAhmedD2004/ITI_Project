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

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Naguib Mahfouz", Bio = "Egyptian writer, 1988 Nobel laureate in Literature, best known for the Cairo Trilogy.", Photo = "/images/author/naguib_mahfouz.png" },
                new Author { Id = 2, Name = "Gabriel García Márquez", Bio = "Colombian novelist and journalist, pioneer of magical realism.", Photo = "/images/author/gabriel_marquez.png" },
                new Author { Id = 3, Name = "Carlos Ruiz Zafón", Bio = "Spanish novelist known for The Cemetery of Forgotten Books series.", Photo = "/images/author/carlos_zafon.png" },
                new Author { Id = 4, Name = "Ahlam Mosteghanemi", Bio = "Algerian novelist and poet, one of the best-selling Arabic-language authors.", Photo = "/images/author/ahlam_mosteghanemi.png" },
                new Author { Id = 5, Name = "Ihsan Abdel Quddous", Bio = "Egyptian journalist and novelist known for socially themed romance fiction.", Photo = "/images/author/ihsan_abdelquddous.png" }
            );

            modelBuilder.Entity<Book>().HasData(
                // Naguib Mahfouz
                new Book { Id = 1, Title = "Midaq Alley", ISBN = "9780978000001", Summary = "A portrait of life in a Cairo back alley in the 1940s.", BookLanguage = "Arabic", PublishedYear = 1947, CoverImage = "/images/books/midaq_alley.png", AuthorId = 1, CategoryId = 4 },
                new Book { Id = 2, Title = "Palace Walk", ISBN = "9780978000002", Summary = "The first volume of the Cairo Trilogy, following a Cairo family through changing times.", BookLanguage = "Arabic", PublishedYear = 1956, CoverImage = "/images/books/palace_walk.png", AuthorId = 1, CategoryId = 4 },
                new Book { Id = 3, Title = "Palace of Desire", ISBN = "9780978000003", Summary = "The second volume of the Cairo Trilogy.", BookLanguage = "Arabic", PublishedYear = 1957, CoverImage = "", AuthorId = 1, CategoryId = 4 },
                new Book { Id = 4, Title = "Sugar Street", ISBN = "9780978000004", Summary = "The concluding volume of the Cairo Trilogy.", BookLanguage = "Arabic", PublishedYear = 1957, CoverImage = "", AuthorId = 1, CategoryId = 4 },
                new Book { Id = 5, Title = "The Thief and the Dogs", ISBN = "9780978000005", Summary = "A short, tense novel about a man seeking revenge after prison.", BookLanguage = "Arabic", PublishedYear = 1961, CoverImage = "/images/books/thief_and_dogs.png", AuthorId = 1, CategoryId = 8 },
                new Book { Id = 6, Title = "Miramar", ISBN = "9780978000006", Summary = "Several narrators share their view of the same guesthouse and its residents.", BookLanguage = "Arabic", PublishedYear = 1967, CoverImage = "", AuthorId = 1, CategoryId = 4 },

                // Gabriel García Márquez
                new Book { Id = 7, Title = "One Hundred Years of Solitude", ISBN = "9780978000007", Summary = "The multi-generational story of the Buendía family in the town of Macondo.", BookLanguage = "English", PublishedYear = 1967, CoverImage = "/images/books/hundred_years_solitude.png", AuthorId = 2, CategoryId = 7 },
                new Book { Id = 8, Title = "Love in the Time of Cholera", ISBN = "9780978000008", Summary = "A decades-long love story set on the Caribbean coast of Colombia.", BookLanguage = "English", PublishedYear = 1985, CoverImage = "/images/books/love_in_time_of_cholera.png", AuthorId = 2, CategoryId = 4 },
                new Book { Id = 9, Title = "Chronicle of a Death Foretold", ISBN = "9780978000009", Summary = "A reconstruction of a murder that the whole town knew was coming.", BookLanguage = "English", PublishedYear = 1981, CoverImage = "/images/books/chronicle_of_death_foretold.png", AuthorId = 2, CategoryId = 8 },
                new Book { Id = 10, Title = "The Autumn of the Patriarch", ISBN = "9780978000010", Summary = "A portrait of an aging, unnamed Caribbean dictator.", BookLanguage = "English", PublishedYear = 1975, CoverImage = "", AuthorId = 2, CategoryId = 7 },
                new Book { Id = 11, Title = "No One Writes to the Colonel", ISBN = "9780978000011", Summary = "A retired colonel waits, year after year, for a pension that never arrives.", BookLanguage = "English", PublishedYear = 1961, CoverImage = "", AuthorId = 2, CategoryId = 4 },

                // Carlos Ruiz Zafón
                new Book { Id = 12, Title = "The Shadow of the Wind", ISBN = "9780978000012", Summary = "A boy discovers a mysterious book and is drawn into a decades-old secret in Barcelona.", BookLanguage = "English", PublishedYear = 2001, CoverImage = "/images/books/shadow_of_the_wind.png", AuthorId = 3, CategoryId = 8 },
                new Book { Id = 13, Title = "The Angel's Game", ISBN = "9780978000013", Summary = "A young writer strikes a dangerous deal with a mysterious publisher.", BookLanguage = "English", PublishedYear = 2008, CoverImage = "/images/books/angels_game.png", AuthorId = 3, CategoryId = 8 },
                new Book { Id = 14, Title = "The Prisoner of Heaven", ISBN = "9780978000014", Summary = "A stranger's visit reopens old wounds tied to the Cemetery of Forgotten Books.", BookLanguage = "English", PublishedYear = 2011, CoverImage = "", AuthorId = 3, CategoryId = 8 },
                new Book { Id = 15, Title = "The Labyrinth of the Spirits", ISBN = "9780978000015", Summary = "The concluding novel of the Cemetery of Forgotten Books series.", BookLanguage = "English", PublishedYear = 2016, CoverImage = "", AuthorId = 3, CategoryId = 8 },

                // Ahlam Mosteghanemi
                new Book { Id = 16, Title = "Memory in the Flesh", ISBN = "9780978000016", Summary = "A painter recalls a lost love against the backdrop of Algeria's history.", BookLanguage = "Arabic", PublishedYear = 1993, CoverImage = "", AuthorId = 4, CategoryId = 4 },
                new Book { Id = 17, Title = "Chaos of the Senses", ISBN = "9780978000017", Summary = "A writer blurs the line between her fiction and her own life.", BookLanguage = "Arabic", PublishedYear = 1997, CoverImage = "/images/books/chaos_of_the_senses.png", AuthorId = 4, CategoryId = 4 },
                new Book { Id = 18, Title = "Passer of Beds", ISBN = "9780978000018", Summary = "The concluding novel of the Memory in the Flesh trilogy.", BookLanguage = "Arabic", PublishedYear = 2003, CoverImage = "", AuthorId = 4, CategoryId = 4 },
                new Book { Id = 19, Title = "Black Suits You", ISBN = "9780978000019", Summary = "A singer's fame collides with grief and a complicated love.", BookLanguage = "Arabic", PublishedYear = 2012, CoverImage = "/images/books/black_suits_you.png", AuthorId = 4, CategoryId = 4 },

                // Ihsan Abdel Quddous
                new Book { Id = 20, Title = "I Am Free", ISBN = "9780978000020", Summary = "A young woman pushes back against family and social expectations.", BookLanguage = "Arabic", PublishedYear = 1954, CoverImage = "/images/books/i_am_free.png", AuthorId = 5, CategoryId = 4 },
                new Book { Id = 21, Title = "Don't Let the Sun Put It Out", ISBN = "9780978000021", Summary = "A story of love and loyalty tested by circumstance.", BookLanguage = "Arabic", PublishedYear = 1959, CoverImage = "", AuthorId = 5, CategoryId = 4 },
                new Book { Id = 22, Title = "A Girl's Diary", ISBN = "9780978000022", Summary = "A young woman's private reflections on love and independence.", BookLanguage = "Arabic", PublishedYear = 1955, CoverImage = "", AuthorId = 5, CategoryId = 4 },
                new Book { Id = 23, Title = "I Do Not Sleep", ISBN = "9780978000023", Summary = "A family drama about jealousy and control across generations.", BookLanguage = "Arabic", PublishedYear = 1957, CoverImage = "", AuthorId = 5, CategoryId = 4 }
            );

            // Two copies per book (Ids 1..46)
            var copies = new List<BookCopy>();
            for (int bookId = 1; bookId <= 23; bookId++)
            {
                int copy1Id = (bookId - 1) * 2 + 1;
                int copy2Id = (bookId - 1) * 2 + 2;

                copies.Add(new BookCopy { Id = copy1Id, Barcode = $"BC-{copy1Id:D4}", Status = BookCopyStatus.Available, BookId = bookId });
                copies.Add(new BookCopy { Id = copy2Id, Barcode = $"BC-{copy2Id:D4}", Status = BookCopyStatus.Available, BookId = bookId });
            }
            // Mark a few copies as currently borrowed, matching the seeded Loans below
            copies.First(c => c.Id == 1).Status = BookCopyStatus.Borrowed;   // Midaq Alley
            copies.First(c => c.Id == 3).Status = BookCopyStatus.Borrowed;   // Palace Walk
            copies.First(c => c.Id == 13).Status = BookCopyStatus.Borrowed;  // One Hundred Years of Solitude
            copies.First(c => c.Id == 23).Status = BookCopyStatus.Borrowed;  // The Shadow of the Wind

            modelBuilder.Entity<BookCopy>().HasData(copies);

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, UserName = "admin", Email = "admin@library.local", PhoneNumber = "01000000001", PasswordHash = "Admin@123", Role = Role.Admin, MembershipStartDate = new DateTime(2024, 1, 1), MembershipExpiryDate = new DateTime(2030, 1, 1), IsBlocked = false },
                new Member { Id = 2, UserName = "sara.librarian", Email = "sara.librarian@library.local", PhoneNumber = "01000000002", PasswordHash = "Librarian@123", Role = Role.Librarian, MembershipStartDate = new DateTime(2024, 3, 1), MembershipExpiryDate = new DateTime(2030, 1, 1), IsBlocked = false },
                new Member { Id = 3, UserName = "omar.librarian", Email = "omar.librarian@library.local", PhoneNumber = "01000000003", PasswordHash = "Librarian@123", Role = Role.Librarian, MembershipStartDate = new DateTime(2024, 6, 1), MembershipExpiryDate = new DateTime(2030, 1, 1), IsBlocked = false },

                new Member { Id = 4, UserName = "mostafa_adel", Email = "mostafa.adel@example.com", PhoneNumber = "01011122201", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 9, 1), MembershipExpiryDate = new DateTime(2026, 9, 1), IsBlocked = false },
                new Member { Id = 5, UserName = "farida.hassan", Email = "farida.hassan@example.com", PhoneNumber = "01011122202", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 9, 10), MembershipExpiryDate = new DateTime(2026, 9, 10), IsBlocked = false },
                new Member { Id = 6, UserName = "ahmed.tarek", Email = "ahmed.tarek@example.com", PhoneNumber = "01011122203", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 10, 1), MembershipExpiryDate = new DateTime(2026, 10, 1), IsBlocked = false },
                new Member { Id = 7, UserName = "mona_saeed", Email = "mona.saeed@example.com", PhoneNumber = "01011122204", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 10, 15), MembershipExpiryDate = new DateTime(2026, 10, 15), IsBlocked = false },
                new Member { Id = 8, UserName = "youssef.k", Email = "youssef.k@example.com", PhoneNumber = "01011122205", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 11, 1), MembershipExpiryDate = new DateTime(2026, 11, 1), IsBlocked = false },
                new Member { Id = 9, UserName = "nourhan.ali", Email = "nourhan.ali@example.com", PhoneNumber = "01011122206", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 11, 20), MembershipExpiryDate = new DateTime(2026, 11, 20), IsBlocked = false },
                new Member { Id = 10, UserName = "karim.mostafa", Email = "karim.mostafa@example.com", PhoneNumber = "01011122207", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 12, 1), MembershipExpiryDate = new DateTime(2026, 12, 1), IsBlocked = false },
                new Member { Id = 11, UserName = "salma.ibrahim", Email = "salma.ibrahim@example.com", PhoneNumber = "01011122208", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 1, 5), MembershipExpiryDate = new DateTime(2027, 1, 5), IsBlocked = false },
                new Member { Id = 12, UserName = "hassan.fouad", Email = "hassan.fouad@example.com", PhoneNumber = "01011122209", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 1, 20), MembershipExpiryDate = new DateTime(2027, 1, 20), IsBlocked = false },
                new Member { Id = 13, UserName = "dina.mahmoud", Email = "dina.mahmoud@example.com", PhoneNumber = "01011122210", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 2, 1), MembershipExpiryDate = new DateTime(2027, 2, 1), IsBlocked = false },
                new Member { Id = 14, UserName = "amr.samir", Email = "amr.samir@example.com", PhoneNumber = "01011122211", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 2, 15), MembershipExpiryDate = new DateTime(2027, 2, 15), IsBlocked = false },
                new Member { Id = 15, UserName = "yasmin.adel", Email = "yasmin.adel@example.com", PhoneNumber = "01011122212", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 3, 1), MembershipExpiryDate = new DateTime(2027, 3, 1), IsBlocked = false },
                new Member { Id = 16, UserName = "tarek.nabil", Email = "tarek.nabil@example.com", PhoneNumber = "01011122213", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 3, 20), MembershipExpiryDate = new DateTime(2027, 3, 20), IsBlocked = false },
                new Member { Id = 17, UserName = "rania.mostafa", Email = "rania.mostafa@example.com", PhoneNumber = "01011122214", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 4, 1), MembershipExpiryDate = new DateTime(2027, 4, 1), IsBlocked = false },
                new Member { Id = 18, UserName = "mohamed.essam", Email = "mohamed.essam@example.com", PhoneNumber = "01011122215", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 4, 15), MembershipExpiryDate = new DateTime(2027, 4, 15), IsBlocked = false },
                new Member { Id = 19, UserName = "heba.khaled", Email = "heba.khaled@example.com", PhoneNumber = "01011122216", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 5, 1), MembershipExpiryDate = new DateTime(2027, 5, 1), IsBlocked = false },
                new Member { Id = 20, UserName = "ali.hassan", Email = "ali.hassan@example.com", PhoneNumber = "01011122217", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 5, 20), MembershipExpiryDate = new DateTime(2027, 5, 20), IsBlocked = false },
                new Member { Id = 21, UserName = "mariam.said", Email = "mariam.said@example.com", PhoneNumber = "01011122218", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2025, 6, 1), MembershipExpiryDate = new DateTime(2026, 6, 1), IsBlocked = true },
                new Member { Id = 22, UserName = "khaled.omar", Email = "khaled.omar@example.com", PhoneNumber = "01011122219", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 6, 15), MembershipExpiryDate = new DateTime(2027, 6, 15), IsBlocked = false },
                new Member { Id = 23, UserName = "nada.fathy", Email = "nada.fathy@example.com", PhoneNumber = "01011122220", PasswordHash = "Member@123", Role = Role.Member, MembershipStartDate = new DateTime(2026, 7, 1), MembershipExpiryDate = new DateTime(2027, 7, 1), IsBlocked = false }
            );

            modelBuilder.Entity<Loan>().HasData(
    new Loan { Id = 1, RequestDate = new DateTime(2026, 8, 20), BorrowDate = new DateTime(2026, 8, 20), DueDate = new DateTime(2026, 9, 3), ReturnDate = null, Status = LoanStatus.Active, BookCopyId = 1, MemberId = 4 },   // overdue
    new Loan { Id = 2, RequestDate = new DateTime(2026, 9, 5), BorrowDate = new DateTime(2026, 9, 5), DueDate = new DateTime(2026, 9, 19), ReturnDate = null, Status = LoanStatus.Active, BookCopyId = 3, MemberId = 5 },  // current
    new Loan { Id = 3, RequestDate = new DateTime(2026, 9, 1), BorrowDate = new DateTime(2026, 9, 1), DueDate = new DateTime(2026, 9, 15), ReturnDate = null, Status = LoanStatus.Active, BookCopyId = 13, MemberId = 6 }, // current
    new Loan { Id = 4, RequestDate = new DateTime(2026, 8, 25), BorrowDate = new DateTime(2026, 8, 25), DueDate = new DateTime(2026, 9, 8), ReturnDate = null, Status = LoanStatus.Active, BookCopyId = 23, MemberId = 7 }  // overdue
);

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, BookId = 1, MemberId = 8, Rating = 5, Comment = "A vivid portrait of Cairo life, still feels alive today.", CreatedDate = new DateTime(2026, 6, 1) },
                new Review { Id = 2, BookId = 7, MemberId = 9, Rating = 5, Comment = "Magical and unforgettable, unlike anything else I've read.", CreatedDate = new DateTime(2026, 5, 15) },
                new Review { Id = 3, BookId = 12, MemberId = 10, Rating = 4, Comment = "Beautifully atmospheric mystery set in Barcelona.", CreatedDate = new DateTime(2026, 4, 20) },
                new Review { Id = 4, BookId = 17, MemberId = 11, Rating = 5, Comment = "Poetic and deeply moving, hard to put down.", CreatedDate = new DateTime(2026, 3, 10) },
                new Review { Id = 5, BookId = 20, MemberId = 12, Rating = 4, Comment = "A powerful story about independence and self-respect.", CreatedDate = new DateTime(2026, 2, 14) }
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
