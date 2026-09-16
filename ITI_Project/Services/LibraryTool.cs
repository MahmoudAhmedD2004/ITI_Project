using Azure.Identity;
using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OpenAI.Realtime;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace ITI_Project.Services
{
    public class LibraryTool(AppDbContext context)
    {
        public List<(string Tool, string Result)> Steps { get; set; } = new();

        //===================================================================
        // Extra (GetBookDetails  &&  GetBooksByAuthor && ListBooksByCategory )
        //===================================================================

        [Description("Get details of a specific book by its title, including author, category, and published year. ")]
        public async Task<string> GetBookDetails([Description("The title of the book, e.g. Palace Walk")] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Record("GetBookDetails", JsonSerializer.Serialize(new {error = "Please provide a valid book title"}));

            var found = await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Title.ToLower().Contains(title.ToLower()));

            if (found is null)
                return Record("GetBookDetails", JsonSerializer.Serialize(new { error = "Book not found in the library" }));

            return Record("GetBookDetails", JsonSerializer.Serialize(new
            {
                title = found.Title,
                author = found.Author?.Name ?? "UnKnown",
                Category = found.Category?.Name ?? "General",
                publishedYear = found.PublishedYear

            }));
        }


        [Description("Get all books written a specific author and their bio. ")]
        public async Task<string> GetBooksByAuthor([Description("Author name e.g Naguib Mahfouz")]string authorName)
        {
            if (string.IsNullOrWhiteSpace(authorName))
                return Record("GetBooksByAuthor", JsonSerializer.Serialize(new { error = "Please provide an author name" }));

            var found = await context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync( a => a.Name.ToLower().Contains(authorName.ToLower()));

            if (found is null)
                return Record("GetBooksByAuthor", JsonSerializer.Serialize(new { error = "Author not found" }));

            return Record("GetBooksByAuthor", JsonSerializer.Serialize(new
            {
                authorName = found.Name,
                bio = found.Bio,
                totalBooks = found.Books.Count(),
                books = found.Books.Select(b => b.Title).ToList()
            }));
        }

        
        [Description("List all books under a specific category.")]
        public async Task<string> ListBooksByCategory([Description("Category name e.g Travel")] string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return Record("ListBooksByCategory", JsonSerializer.Serialize(new { error = "Please provide a category name" }));

            var found = await context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Name.ToLower().Contains(categoryName));

            if (found is null)
                return Record("ListBooksByCategory", JsonSerializer.Serialize(new { error = "Category not found" }));
            
            var booksList = found.Books.Select(b => new { 
                b.Title,
                b.PublishedYear}).ToList();

            return Record("ListBooksByCategory", JsonSerializer.Serialize(new
            {
                category = found.Name,
                totalBooks = booksList.Count(),
                books = booksList
            }));
        }
        //========================================================================================================================
        // Agent version. Tools SearchBooks , GetMyLoans and ReserveBook — the member says "reserve me the next copy of that novel"
        //and it happens.
        //========================================================================================================================


        [Description("Search for book by title, author name, or category")]
        public async Task<string> SearchBooks([Description("Search query e.g. title, author name, or category")] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return Record("SearchBooks", JsonSerializer.Serialize(new { error = "Please provide a valid search query" }));

            var books = await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.BookCopies)
                .Where(b => b.Title.ToLower().Contains(query.ToLower()) ||
                       b.Author.Name.ToLower().Contains(query.ToLower()) ||
                       b.Category.Name.ToLower().Contains(query.ToLower()))
                .Select(b => new
                {
                    bookId = b.Id,
                    title = b.Title,
                    author = b.Author.Name,
                    isAvailable = b.BookCopies.Any(bc => bc.Status == Model.BookCopyStatus.Available)
                })
                .ToListAsync();

            if (!books.Any())
                return Record("SearchBooks", JsonSerializer.Serialize(new { message = "No books found matching your query" }));

            return Record("SearchBooks", JsonSerializer.Serialize(books));
        }



        [Description("Get all current book loans and borrowing history for a specific user.")]
        public async Task<string> GetMyLoans([Description("The unique member ID (integer) e.g. 1")] int memberId)
        {
            if (memberId <= 0)
                return Record("GetMyLoans", JsonSerializer.Serialize(new { error = "Valid Member ID is required" }));

            var memberExists = await context.Members.AnyAsync(m => m.Id == memberId);

            if (!memberExists)
                return Record("GetMyLoans", JsonSerializer.Serialize(new { error = "Member not found" }));

            var loans = await context.Loans
                .AsNoTracking()
                .Include(l => l.BookCopy)
                    .ThenInclude(bc => bc.Book)
                .Where(l => l.MemberId == memberId &&
                        l.Status != Model.LoanStatus.Returned &&
                        l.Status != Model.LoanStatus.Rejected &&
                        l.Status != Model.LoanStatus.Cancelled)
                .Select(l => new
                {
                    loanId = l.Id,

                    bookTitle = l.BookCopy != null && 
                    l.BookCopy.Book != null ? l.BookCopy.Book.Title : "Unknown",

                    copyId = l.BookCopyId,
                    status = l.Status.ToString(),
                    requestDate = l.RequestDate.ToString("yyyy-MM-dd"),
                    borrowDate = l.BorrowDate.HasValue ? l.BorrowDate.Value.ToString("yyyy-MM-dd") : "Pending Approval",
                    DueDate = l.DueDate.HasValue ? l.DueDate.Value.ToString("yyyy-MM-dd") : "N/A"
                })
                .ToListAsync();

                if (!loans.Any())
                    return Record("GetMyLoans", JsonSerializer.Serialize(new { message = "You currently have no loans or active requests" }));

            return Record("GetMyLoans", JsonSerializer.Serialize(loans));
        }


        [Description("Reserve a copy of a specific book for a member.")]
        public async Task<string> ReserveBook([Description("The exact title or partial title of the book to reserve")] string bookTitle,
            [Description("The unique member ID (integer) requesting the reservation")] int memberId)
        {
            if (string.IsNullOrWhiteSpace(bookTitle) || memberId <= 0)
                return Record("ReserveBook", JsonSerializer.Serialize(new { error = "Book title and valid Member ID are reqired" }));

            // Exist Member ?
            var member = await context.Members.FindAsync(memberId);
            if (member is null)
                return Record("ReserveBook", JsonSerializer.Serialize(new { error = "Member not found" }));
            // Member is Blocked ?
            if (member.IsBlocked)
                return Record("ReserveBook", JsonSerializer.Serialize(new { error = "Account is blocked from making reservations" }));

            // search for  book 
            var book = await context.Books
                .Include(b => b.BookCopies)
                .FirstOrDefaultAsync(b => b.Title.ToLower().Contains(bookTitle.ToLower()));

            if (book is null)
                return Record("ReserveBook", JsonSerializer.Serialize(new {error = "Book not found" }));

            var newReservation = new Reservation
            {
                BookId = book.Id,
                MemberId = memberId,
                ReservationDate = DateTime.Now
            };

            context.Reservations.Add(newReservation);
            await context.SaveChangesAsync();

            return Record("ReserveBook", JsonSerializer.Serialize(new
            {
                success = true,
                message = $"Successflly reserved '{book.Title}' for member ID {memberId}.",
                reservationId = newReservation.Id,
                reservationDate = newReservation.ReservationDate.ToString("yyyy-MM-dd")

            }));

        }

        private string Record(string tool, string result)
        {
            Steps.Add((tool, result));
            return result;
        }
    }
}
