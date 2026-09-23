# 📚 ITI Library Management System (LibraryMvc)

A team project for the **ASP.NET Core MVC** course at **ITI**, built around the "Library Management System" idea from the "Team Project Ideas" brief (by instructor Mazen Barakat).

The system lets members browse, reserve, and borrow books, while admins manage loans and fines from a dashboard — plus an AI chat assistant that answers member questions about books and loans.

---

## ✨ Key Features

- **Book Management**: browse, search, filter and sort, details, add a book with cover image upload, and reports (`BookController`).
- **Authors & Categories**: full CRUD operations (`AuthorsController`, `CategoriesController`).
- **Members**:
  - Custom login/signup system (not ASP.NET Identity) built on Cookie Authentication.
  - Profile management, password change, and admin member management (`MemberController`, `MembersController`).
- **Loans & Reservations**:
  - Request a loan, track "My Loans", pending requests, pending returns, and loan review (`LoanController`).
  - Reservation system for unavailable books (`ReservationsController`).
  - Fine calculation and display for overdue loans.
- **Favorites**: members can bookmark favorite books (`FavoritesController`).
- **Ebooks**: catalog and in-site reading of ebooks (`EbooksController`).
- **AI Chat Assistant**:
  - A chatbot (`ChatController`) built on `Microsoft.Extensions.AI`, using a model served via **OpenRouter**.
  - Answers only through defined tools (`LibraryTool`) rather than inventing data about book availability or loans.
- **Reviews**: members can rate and review books.

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| Framework | ASP.NET Core MVC |
| Database | SQL Server + Entity Framework Core (Code-First Migrations) |
| Authentication | Cookie Authentication (custom login/signup system) |
| Sessions | Session (Distributed Memory Cache) |
| AI | Microsoft.Extensions.AI + OpenAI SDK (connected to OpenRouter) |
| Frontend | Razor Views (.cshtml), Bootstrap, jQuery, jQuery Validation |

---

## 🗂️ Project Structure

```
ITI_Project/
├── Controllers/       # Authors, Book, Categories, Chat, Ebooks, Favorites, Home, Loan, Member(s), Reservations
├── Model/              # Author, Book, BookCopy, Category, Ebook, Favorite, Fine, Loan, Member, Reservation, Review
├── ModelView/          # ViewModels for each operation (Create/Edit/Report/Filter, etc.)
├── Data/               # AppDbContext (EF Core)
├── Migrations/         # EF Core migration history
├── Services/           # AiService, LibraryTool (AI assistant tools)
├── Views/              # Razor pages for each controller
├── wwwroot/            # Static assets (CSS/JS, book/author images, uploads)
└── Program.cs          # App entry point and service configuration
```

The repository root also includes **ERD.png / ERD.html**, showing the database Entity Relationship Diagram.

---

## ⚙️ Requirements

- .NET SDK (matching the project's target version, typically .NET 8/9).
- SQL Server (local instance or LocalDB).
- (Optional) An [OpenRouter](https://openrouter.ai) API key to enable the chatbot feature.

## ▶️ Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/MahmoudAhmedD2004/ITI_Project.git
   cd ITI_Project
   ```

2. **Configure the database connection string**

   In `ITI_Project/appsettings.json`, update `ConnectionStrings.constr` to match your SQL Server setup:
   ```json
   "ConnectionStrings": {
     "constr": "Server=.;Database=ITI_ProjectDb;integrated Security=SSPI;TrustServerCertificate=True"
   }
   ```

3. **Configure the AI key (optional, required only for the chatbot)**

   ```json
   "AI": {
     "BaseUrl": "https://openrouter.ai/api/v1",
     "Model": "google/gemini-2.5-flash-lite",
     "ApiKey": "your_api_key_here"
   }
   ```

4. **Apply migrations and create the database**
   ```bash
   dotnet ef database update --project ITI_Project
   ```

5. **Run the project**
   ```bash
   dotnet run --project ITI_Project
   ```

   The default landing page is `Book/Index`.

---

## 📝 Notes

- The login system is fully custom (not ASP.NET Identity), so authentication and password handling are implemented manually in `MemberController`.
- The chatbot won't work without a valid `ApiKey` set under the `AI` section in `appsettings.json`.
- Never commit real API keys in `appsettings.json` when pushing to a public repository — prefer User Secrets or environment variables instead.

---

## 👥 Team

A team course/graduation project built by a group of ITI students, continued and extended on top of a base repository created by one of the team members.
