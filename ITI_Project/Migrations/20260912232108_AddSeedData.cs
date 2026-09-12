using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Name", "Photo" },
                values: new object[,]
                {
                    { 1, "Egyptian writer, 1988 Nobel laureate in Literature, best known for the Cairo Trilogy.", "Naguib Mahfouz", "/images/author/naguib_mahfouz.png" },
                    { 2, "Colombian novelist and journalist, pioneer of magical realism.", "Gabriel García Márquez", "/images/author/gabriel_marquez.png" },
                    { 3, "Spanish novelist known for The Cemetery of Forgotten Books series.", "Carlos Ruiz Zafón", "/images/author/carlos_zafon.png" },
                    { 4, "Algerian novelist and poet, one of the best-selling Arabic-language authors.", "Ahlam Mosteghanemi", "/images/author/ahlam_mosteghanemi.png" },
                    { 5, "Egyptian journalist and novelist known for socially themed romance fiction.", "Ihsan Abdel Quddous", "/images/author/ihsan_abdelquddous.png" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "IsBlocked", "MembershipExpiryDate", "MembershipStartDate", "PasswordHash", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@library.local", false, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@123", "01000000001", 2, "admin" },
                    { 2, "sara.librarian@library.local", false, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Librarian@123", "01000000002", 1, "sara.librarian" },
                    { 3, "omar.librarian@library.local", false, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Librarian@123", "01000000003", 1, "omar.librarian" },
                    { 4, "mostafa.adel@example.com", false, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122201", 0, "mostafa_adel" },
                    { 5, "farida.hassan@example.com", false, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122202", 0, "farida.hassan" },
                    { 6, "ahmed.tarek@example.com", false, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122203", 0, "ahmed.tarek" },
                    { 7, "mona.saeed@example.com", false, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122204", 0, "mona_saeed" },
                    { 8, "youssef.k@example.com", false, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122205", 0, "youssef.k" },
                    { 9, "nourhan.ali@example.com", false, new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122206", 0, "nourhan.ali" },
                    { 10, "karim.mostafa@example.com", false, new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122207", 0, "karim.mostafa" },
                    { 11, "salma.ibrahim@example.com", false, new DateTime(2027, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122208", 0, "salma.ibrahim" },
                    { 12, "hassan.fouad@example.com", false, new DateTime(2027, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122209", 0, "hassan.fouad" },
                    { 13, "dina.mahmoud@example.com", false, new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122210", 0, "dina.mahmoud" },
                    { 14, "amr.samir@example.com", false, new DateTime(2027, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122211", 0, "amr.samir" },
                    { 15, "yasmin.adel@example.com", false, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122212", 0, "yasmin.adel" },
                    { 16, "tarek.nabil@example.com", false, new DateTime(2027, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122213", 0, "tarek.nabil" },
                    { 17, "rania.mostafa@example.com", false, new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122214", 0, "rania.mostafa" },
                    { 18, "mohamed.essam@example.com", false, new DateTime(2027, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122215", 0, "mohamed.essam" },
                    { 19, "heba.khaled@example.com", false, new DateTime(2027, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122216", 0, "heba.khaled" },
                    { 20, "ali.hassan@example.com", false, new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122217", 0, "ali.hassan" },
                    { 21, "mariam.said@example.com", true, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122218", 0, "mariam.said" },
                    { 22, "khaled.omar@example.com", false, new DateTime(2027, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122219", 0, "khaled.omar" },
                    { 23, "nada.fathy@example.com", false, new DateTime(2027, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01011122220", 0, "nada.fathy" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Arabic", 4, "/images/books/midaq_alley.png", "9780978000001", 1947, "A portrait of life in a Cairo back alley in the 1940s.", "Midaq Alley" },
                    { 2, 1, "Arabic", 4, "/images/books/palace_walk.png", "9780978000002", 1956, "The first volume of the Cairo Trilogy, following a Cairo family through changing times.", "Palace Walk" },
                    { 3, 1, "Arabic", 4, "", "9780978000003", 1957, "The second volume of the Cairo Trilogy.", "Palace of Desire" },
                    { 4, 1, "Arabic", 4, "", "9780978000004", 1957, "The concluding volume of the Cairo Trilogy.", "Sugar Street" },
                    { 5, 1, "Arabic", 8, "/images/books/thief_and_dogs.png", "9780978000005", 1961, "A short, tense novel about a man seeking revenge after prison.", "The Thief and the Dogs" },
                    { 6, 1, "Arabic", 4, "", "9780978000006", 1967, "Several narrators share their view of the same guesthouse and its residents.", "Miramar" },
                    { 7, 2, "English", 7, "/images/books/hundred_years_solitude.png", "9780978000007", 1967, "The multi-generational story of the Buendía family in the town of Macondo.", "One Hundred Years of Solitude" },
                    { 8, 2, "English", 4, "/images/books/love_in_time_of_cholera.png", "9780978000008", 1985, "A decades-long love story set on the Caribbean coast of Colombia.", "Love in the Time of Cholera" },
                    { 9, 2, "English", 8, "/images/books/chronicle_of_death_foretold.png", "9780978000009", 1981, "A reconstruction of a murder that the whole town knew was coming.", "Chronicle of a Death Foretold" },
                    { 10, 2, "English", 7, "", "9780978000010", 1975, "A portrait of an aging, unnamed Caribbean dictator.", "The Autumn of the Patriarch" },
                    { 11, 2, "English", 4, "", "9780978000011", 1961, "A retired colonel waits, year after year, for a pension that never arrives.", "No One Writes to the Colonel" },
                    { 12, 3, "English", 8, "/images/books/shadow_of_the_wind.png", "9780978000012", 2001, "A boy discovers a mysterious book and is drawn into a decades-old secret in Barcelona.", "The Shadow of the Wind" },
                    { 13, 3, "English", 8, "/images/books/angels_game.png", "9780978000013", 2008, "A young writer strikes a dangerous deal with a mysterious publisher.", "The Angel's Game" },
                    { 14, 3, "English", 8, "", "9780978000014", 2011, "A stranger's visit reopens old wounds tied to the Cemetery of Forgotten Books.", "The Prisoner of Heaven" },
                    { 15, 3, "English", 8, "", "9780978000015", 2016, "The concluding novel of the Cemetery of Forgotten Books series.", "The Labyrinth of the Spirits" },
                    { 16, 4, "Arabic", 4, "", "9780978000016", 1993, "A painter recalls a lost love against the backdrop of Algeria's history.", "Memory in the Flesh" },
                    { 17, 4, "Arabic", 4, "/images/books/chaos_of_the_senses.png", "9780978000017", 1997, "A writer blurs the line between her fiction and her own life.", "Chaos of the Senses" },
                    { 18, 4, "Arabic", 4, "", "9780978000018", 2003, "The concluding novel of the Memory in the Flesh trilogy.", "Passer of Beds" },
                    { 19, 4, "Arabic", 4, "/images/books/black_suits_you.png", "9780978000019", 2012, "A singer's fame collides with grief and a complicated love.", "Black Suits You" },
                    { 20, 5, "Arabic", 4, "/images/books/i_am_free.png", "9780978000020", 1954, "A young woman pushes back against family and social expectations.", "I Am Free" },
                    { 21, 5, "Arabic", 4, "", "9780978000021", 1959, "A story of love and loyalty tested by circumstance.", "Don't Let the Sun Put It Out" },
                    { 22, 5, "Arabic", 4, "", "9780978000022", 1955, "A young woman's private reflections on love and independence.", "A Girl's Diary" },
                    { 23, 5, "Arabic", 4, "", "9780978000023", 1957, "A family drama about jealousy and control across generations.", "I Do Not Sleep" }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "Barcode", "BookId", "Status" },
                values: new object[,]
                {
                    { 1, "BC-0001", 1, "Borrowed" },
                    { 2, "BC-0002", 1, "Available" },
                    { 3, "BC-0003", 2, "Borrowed" },
                    { 4, "BC-0004", 2, "Available" },
                    { 5, "BC-0005", 3, "Available" },
                    { 6, "BC-0006", 3, "Available" },
                    { 7, "BC-0007", 4, "Available" },
                    { 8, "BC-0008", 4, "Available" },
                    { 9, "BC-0009", 5, "Available" },
                    { 10, "BC-0010", 5, "Available" },
                    { 11, "BC-0011", 6, "Available" },
                    { 12, "BC-0012", 6, "Available" },
                    { 13, "BC-0013", 7, "Borrowed" },
                    { 14, "BC-0014", 7, "Available" },
                    { 15, "BC-0015", 8, "Available" },
                    { 16, "BC-0016", 8, "Available" },
                    { 17, "BC-0017", 9, "Available" },
                    { 18, "BC-0018", 9, "Available" },
                    { 19, "BC-0019", 10, "Available" },
                    { 20, "BC-0020", 10, "Available" },
                    { 21, "BC-0021", 11, "Available" },
                    { 22, "BC-0022", 11, "Available" },
                    { 23, "BC-0023", 12, "Borrowed" },
                    { 24, "BC-0024", 12, "Available" },
                    { 25, "BC-0025", 13, "Available" },
                    { 26, "BC-0026", 13, "Available" },
                    { 27, "BC-0027", 14, "Available" },
                    { 28, "BC-0028", 14, "Available" },
                    { 29, "BC-0029", 15, "Available" },
                    { 30, "BC-0030", 15, "Available" },
                    { 31, "BC-0031", 16, "Available" },
                    { 32, "BC-0032", 16, "Available" },
                    { 33, "BC-0033", 17, "Available" },
                    { 34, "BC-0034", 17, "Available" },
                    { 35, "BC-0035", 18, "Available" },
                    { 36, "BC-0036", 18, "Available" },
                    { 37, "BC-0037", 19, "Available" },
                    { 38, "BC-0038", 19, "Available" },
                    { 39, "BC-0039", 20, "Available" },
                    { 40, "BC-0040", 20, "Available" },
                    { 41, "BC-0041", 21, "Available" },
                    { 42, "BC-0042", 21, "Available" },
                    { 43, "BC-0043", 22, "Available" },
                    { 44, "BC-0044", 22, "Available" },
                    { 45, "BC-0045", 23, "Available" },
                    { 46, "BC-0046", 23, "Available" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[,]
                {
                    { 1, 1, "A vivid portrait of Cairo life, still feels alive today.", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 },
                    { 2, 7, "Magical and unforgettable, unlike anything else I've read.", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5 },
                    { 3, 12, "Beautifully atmospheric mystery set in Barcelona.", new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 },
                    { 4, 17, "Poetic and deeply moving, hard to put down.", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5 },
                    { 5, 20, "A powerful story about independence and self-respect.", new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "BorrowDate", "DueDate", "MemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 2, 3, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null },
                    { 3, 13, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null },
                    { 4, 23, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
