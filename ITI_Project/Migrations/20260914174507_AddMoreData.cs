using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Egyptian Nobel Prize winning novelist.", "" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "Name", "Photo" },
                values: new object[] { "Colombian novelist and magical realism pioneer.", "Gabriel Garcia Marquez", "" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "Name", "Photo" },
                values: new object[] { "Spanish novelist known for literary mysteries.", "Carlos Ruiz Zafon", "" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Algerian novelist and poet.", "" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Egyptian journalist and novelist.", "" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Name", "Photo" },
                values: new object[,]
                {
                    { 6, "English mystery novelist.", "Agatha Christie", "" },
                    { 7, "Writer focused on habits and behavior.", "James Clear", "" },
                    { 8, "English fantasy writer.", "Neil Gaiman", "" },
                    { 9, "Historian and writer.", "Yuval Noah Harari", "" },
                    { 10, "Brazilian novelist.", "Paulo Coelho", "" },
                    { 11, "English novelist.", "Jane Austen", "" },
                    { 12, "British mystery writer.", "Arthur Conan Doyle", "" }
                });

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 31,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 33,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 35,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 36,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 37,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 38,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 39,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 40,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 41,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 42,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 43,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 44,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 45,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "English", 1, "", "9780000000001", 1981, "A complete test summary for Midaq Alley." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, "English", 2, "", "9780000000002", 1982, "A complete test summary for Palace Walk." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 3, 3, "9780000000003", 1983, "A complete test summary for Palace of Desire." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "BookLanguage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 4, "English", "9780000000004", 1984, "A complete test summary for Sugar Street." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 5, "English", 5, "", "9780000000005", 1985, "A complete test summary for The Thief and the Dogs." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 6, 6, "9780000000006", 1986, "A complete test summary for Miramar." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 7, "", "9780000000007", 1987, "A complete test summary for One Hundred Years of Solitude." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 8, 8, "", "9780000000008", 1988, "A complete test summary for Love in the Time of Cholera." });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 9, "", "Psychology" },
                    { 10, "", "Travel" },
                    { 11, "", "Biography" },
                    { 12, "", "Romance" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 9, "Arabic", 9, "", "9780000000009", 1989, "A complete test summary for Chronicle of a Death Foretold." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 10, 10, "9780000000010", 1990, "A complete test summary for The Autumn of the Patriarch." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 11, 11, "9780000000011", 1991, "A complete test summary for No One Writes to the Colonel." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 12, "Arabic", 12, "", "9780000000012", 1992, "A complete test summary for The Shadow of the Wind." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AuthorId", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, 1, "", "9780000000013", 1993, "A complete test summary for The Angel's Game." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, 2, "9780000000014", 1994, "A complete test summary for The Prisoner of Heaven." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "Arabic", 3, "9780000000015", 1995, "A complete test summary for The Labyrinth of the Spirits." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookLanguage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "English", "9780000000016", 1996, "A complete test summary for Memory in the Flesh." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "Summary" },
                values: new object[] { 5, "English", 5, "", "9780000000017", "A complete test summary for Chaos of the Senses." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 6, 6, "9780000000018", 1998, "A complete test summary for Passer of Beds." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 7, "English", 7, "", "9780000000019", 1999, "A complete test summary for Black Suits You." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 8, "English", 8, "", "9780000000020", 2000, "A complete test summary for I Am Free." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 9, 9, "9780000000021", 2001, "A complete test summary for Murder on the Orient Express.", "Murder on the Orient Express" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 10, "English", 10, "9780000000022", 2002, "A complete test summary for And Then There Were None.", "And Then There Were None" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 11, "English", 11, "9780000000023", 2003, "A complete test summary for Atomic Habits.", "Atomic Habits" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[,]
                {
                    { 25, 1, "English", 1, "", "9780000000025", 2005, "A complete test summary for Sapiens.", "Sapiens" },
                    { 26, 2, "English", 2, "", "9780000000026", 2006, "A complete test summary for The Alchemist.", "The Alchemist" },
                    { 27, 3, "Arabic", 3, "", "9780000000027", 2007, "A complete test summary for Pride and Prejudice.", "Pride and Prejudice" },
                    { 28, 4, "English", 4, "", "9780000000028", 2008, "A complete test summary for Sherlock Holmes.", "Sherlock Holmes" },
                    { 29, 5, "English", 5, "", "9780000000029", 2009, "A complete test summary for The Lost Library.", "The Lost Library" },
                    { 37, 1, "English", 1, "", "9780000000037", 2017, "A complete test summary for The Paper Garden.", "The Paper Garden" },
                    { 38, 2, "English", 2, "", "9780000000038", 2018, "A complete test summary for City of Jasmine.", "City of Jasmine" },
                    { 39, 3, "Arabic", 3, "", "9780000000039", 2019, "A complete test summary for Northern Lights.", "Northern Lights" },
                    { 40, 4, "English", 4, "", "9780000000040", 2020, "A complete test summary for Desert Letters.", "Desert Letters" }
                });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "DueDate", "RequestDate" },
                values: new object[] { new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "DueDate", "RequestDate" },
                values: new object[] { new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookCopyId", "BorrowDate", "DueDate", "RequestDate", "Status" },
                values: new object[] { 5, null, null, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookCopyId", "Status" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "BorrowDate", "DueDate", "MemberId", "RejectionReason", "RequestDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 5, 9, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 11, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 13, null, null, 10, "Membership verification is required.", new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 },
                    { 8, 15, null, null, 11, null, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 9, 17, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 10, 19, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, null, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 11, 21, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, null, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 13, 25, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, null, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, 27, null, null, 16, null, new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 },
                    { 15, 29, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 16, 31, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, null, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 17, 33, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, null, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 18, 35, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, null, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 19, 36, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 20, 37, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, null, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 21, 38, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, null, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MembershipStartDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                column: "MembershipStartDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member04@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000004", "member04" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member05@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000005", "member05" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member06@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000006", "member06" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member07@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000007", "member07" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member08@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000008", "member08" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member09@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000009", "member09" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member10@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000010", "member10" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member11@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000011", "member11" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member12@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000012", "member12" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member13@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000013", "member13" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member14@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000014", "member14" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member15@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000015", "member15" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member16@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000016", "member16" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member17@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000017", "member17" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member18@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000018", "member18" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member19@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000019", "member19" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member20@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000020", "member20" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Email", "IsBlocked", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member21@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000021", "member21" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member22@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000022", "member22" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "member23@library.local", new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01030000023", "member23" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "IsBlocked", "MembershipExpiryDate", "MembershipStartDate", "PasswordHash", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 24, "member24@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000024", 0, "member24" },
                    { 25, "member25@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000025", 0, "member25" },
                    { 26, "member26@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000026", 0, "member26" },
                    { 27, "member27@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000027", 0, "member27" },
                    { 28, "member28@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000028", 0, "member28" },
                    { 29, "member29@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000029", 0, "member29" },
                    { 30, "member30@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000030", 0, "member30" },
                    { 31, "member31@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000031", 0, "member31" },
                    { 32, "member32@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000032", 0, "member32" },
                    { 33, "member33@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000033", 0, "member33" },
                    { 34, "member34@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000034", 0, "member34" },
                    { 35, "member35@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000035", 0, "member35" },
                    { 36, "member36@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000036", 0, "member36" },
                    { 37, "member37@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000037", 0, "member37" },
                    { 38, "expired.member@library.local", false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000038", 0, "expired.member" },
                    { 39, "blocked.member@library.local", true, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member@123", "01030000039", 0, "blocked.member" },
                    { 40, "test.member@library.local", false, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test@123", "01030000040", 0, "test.member" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { "Test review number 1 for book 1.", new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 2, "Test review number 2 for book 2.", new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 3, "Test review number 3 for book 3.", new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 4, "Test review number 4 for book 4.", new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 5, "Test review number 5 for book 5.", new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[,]
                {
                    { 6, 6, "Test review number 6 for book 6.", new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 7, 7, "Test review number 7 for book 7.", new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 8, 8, "Test review number 8 for book 8.", new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 3 },
                    { 9, 9, "Test review number 9 for book 9.", new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4 },
                    { 10, 10, "Test review number 10 for book 10.", new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 11, 11, "Test review number 11 for book 11.", new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1 },
                    { 12, 12, "Test review number 12 for book 12.", new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2 },
                    { 13, 13, "Test review number 13 for book 13.", new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 3 },
                    { 14, 14, "Test review number 14 for book 14.", new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4 },
                    { 15, 15, "Test review number 15 for book 15.", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 5 },
                    { 16, 16, "Test review number 16 for book 16.", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 1 },
                    { 17, 17, "Test review number 17 for book 17.", new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2 },
                    { 18, 18, "Test review number 18 for book 18.", new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 3 },
                    { 19, 19, "Test review number 19 for book 19.", new DateTime(2026, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 4 },
                    { 20, 20, "Test review number 20 for book 20.", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "Barcode", "BookId", "Status" },
                values: new object[,]
                {
                    { 49, "BC-0049", 25, 2 },
                    { 50, "BC-0050", 25, 0 },
                    { 51, "BC-0051", 26, 0 },
                    { 52, "BC-0052", 26, 0 },
                    { 53, "BC-0053", 27, 0 },
                    { 54, "BC-0054", 27, 0 },
                    { 55, "BC-0055", 28, 0 },
                    { 56, "BC-0056", 28, 0 },
                    { 57, "BC-0057", 29, 0 },
                    { 58, "BC-0058", 29, 0 },
                    { 73, "BC-0073", 37, 0 },
                    { 74, "BC-0074", 37, 0 },
                    { 75, "BC-0075", 38, 0 },
                    { 76, "BC-0076", 38, 0 },
                    { 77, "BC-0077", 39, 0 },
                    { 78, "BC-0078", 39, 0 },
                    { 79, "BC-0079", 40, 0 },
                    { 80, "BC-0080", 40, 0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[,]
                {
                    { 24, 12, "Arabic", 12, "", "9780000000024", 2004, "A complete test summary for American Gods.", "American Gods" },
                    { 30, 6, "Arabic", 6, "", "9780000000030", 2010, "A complete test summary for Morning in Alexandria.", "Morning in Alexandria" },
                    { 31, 7, "English", 7, "", "9780000000031", 2011, "A complete test summary for Beyond the Dunes.", "Beyond the Dunes" },
                    { 32, 8, "English", 8, "", "9780000000032", 2012, "A complete test summary for The Midnight Archive.", "The Midnight Archive" },
                    { 33, 9, "Arabic", 9, "", "9780000000033", 2013, "A complete test summary for River Without Maps.", "River Without Maps" },
                    { 34, 10, "English", 10, "", "9780000000034", 2014, "A complete test summary for The Small Observatory.", "The Small Observatory" },
                    { 35, 11, "English", 11, "", "9780000000035", 2015, "A complete test summary for Silent Equations.", "Silent Equations" },
                    { 36, 12, "Arabic", 12, "", "9780000000036", 2016, "A complete test summary for A Map of Stars.", "A Map of Stars" }
                });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "Id", "Amount", "CreatedDate", "IsPaid", "LoanId" },
                values: new object[,]
                {
                    { 1, 30m, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5 },
                    { 2, 55m, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "BorrowDate", "DueDate", "MemberId", "RejectionReason", "RequestDate", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 12, 23, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, null, new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 22, 39, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 23, 40, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, null, new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 24, 41, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, null, new DateTime(2026, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 25, 42, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, null, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 26, 43, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, null, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 27, 44, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, null, new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 28, 45, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, null, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookId", "MemberId", "ReservationDate", "Status" },
                values: new object[,]
                {
                    { 1, 20, 24, new DateTime(2026, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 2, 20, 25, new DateTime(2026, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 3, 20, 26, new DateTime(2026, 9, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 4, 21, 27, new DateTime(2026, 9, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 5, 21, 28, new DateTime(2026, 9, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 8, 25, 31, new DateTime(2026, 9, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 9, 26, 32, new DateTime(2026, 9, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "Fulfilled" },
                    { 10, 27, 33, new DateTime(2026, 9, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[,]
                {
                    { 21, 21, "Test review number 21 for book 21.", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1 },
                    { 22, 22, "Test review number 22 for book 22.", new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2 },
                    { 23, 23, "Test review number 23 for book 23.", new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3 },
                    { 25, 25, "Test review number 25 for book 25.", new DateTime(2026, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 5 },
                    { 26, 26, "Test review number 26 for book 26.", new DateTime(2026, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 1 },
                    { 27, 27, "Test review number 27 for book 27.", new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 2 },
                    { 28, 28, "Test review number 28 for book 28.", new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 3 },
                    { 29, 29, "Test review number 29 for book 29.", new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4 }
                });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "Id", "Barcode", "BookId", "Status" },
                values: new object[,]
                {
                    { 47, "BC-0047", 24, 1 },
                    { 48, "BC-0048", 24, 0 },
                    { 59, "BC-0059", 30, 0 },
                    { 60, "BC-0060", 30, 0 },
                    { 61, "BC-0061", 31, 0 },
                    { 62, "BC-0062", 31, 0 },
                    { 63, "BC-0063", 32, 0 },
                    { 64, "BC-0064", 32, 0 },
                    { 65, "BC-0065", 33, 0 },
                    { 66, "BC-0066", 33, 0 },
                    { 67, "BC-0067", 34, 0 },
                    { 68, "BC-0068", 34, 0 },
                    { 69, "BC-0069", 35, 0 },
                    { 70, "BC-0070", 35, 0 },
                    { 71, "BC-0071", 36, 0 },
                    { 72, "BC-0072", 36, 0 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "BorrowDate", "DueDate", "MemberId", "RejectionReason", "RequestDate", "ReturnDate", "Status" },
                values: new object[] { 30, 49, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, null, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BookId", "MemberId", "ReservationDate", "Status" },
                values: new object[,]
                {
                    { 6, 24, 29, new DateTime(2026, 9, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 7, 24, 30, new DateTime(2026, 9, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[,]
                {
                    { 24, 24, "Test review number 24 for book 24.", new DateTime(2026, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4 },
                    { 30, 30, "Test review number 30 for book 30.", new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 5 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "BookCopyId", "BorrowDate", "DueDate", "MemberId", "RejectionReason", "RequestDate", "ReturnDate", "Status" },
                values: new object[] { 29, 47, null, null, 31, null, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Egyptian writer, 1988 Nobel laureate in Literature, best known for the Cairo Trilogy.", "/images/author/naguib_mahfouz.png" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "Name", "Photo" },
                values: new object[] { "Colombian novelist and journalist, pioneer of magical realism.", "Gabriel García Márquez", "/images/author/gabriel_marquez.png" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "Name", "Photo" },
                values: new object[] { "Spanish novelist known for The Cemetery of Forgotten Books series.", "Carlos Ruiz Zafón", "/images/author/carlos_zafon.png" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Algerian novelist and poet, one of the best-selling Arabic-language authors.", "/images/author/ahlam_mosteghanemi.png" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Bio", "Photo" },
                values: new object[] { "Egyptian journalist and novelist known for socially themed romance fiction.", "/images/author/ihsan_abdelquddous.png" });

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 31,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 33,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 35,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 36,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 37,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 38,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 39,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 40,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 41,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 42,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 43,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 44,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BookCopies",
                keyColumn: "Id",
                keyValue: 45,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "Arabic", 4, "/images/books/midaq_alley.png", "9780978000001", 1947, "A portrait of life in a Cairo back alley in the 1940s." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, "Arabic", 4, "/images/books/palace_walk.png", "9780978000002", 1956, "The first volume of the Cairo Trilogy, following a Cairo family through changing times." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, 4, "9780978000003", 1957, "The second volume of the Cairo Trilogy." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "BookLanguage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, "Arabic", "9780978000004", 1957, "The concluding volume of the Cairo Trilogy." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, "Arabic", 8, "/images/books/thief_and_dogs.png", "9780978000005", 1961, "A short, tense novel about a man seeking revenge after prison." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 1, 4, "9780978000006", 1967, "Several narrators share their view of the same guesthouse and its residents." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, "/images/books/hundred_years_solitude.png", "9780978000007", 1967, "The multi-generational story of the Buendía family in the town of Macondo." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, 4, "/images/books/love_in_time_of_cholera.png", "9780978000008", 1985, "A decades-long love story set on the Caribbean coast of Colombia." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, "English", 8, "/images/books/chronicle_of_death_foretold.png", "9780978000009", 1981, "A reconstruction of a murder that the whole town knew was coming." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, 7, "9780978000010", 1975, "A portrait of an aging, unnamed Caribbean dictator." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 2, 4, "9780978000011", 1961, "A retired colonel waits, year after year, for a pension that never arrives." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 3, "English", 8, "/images/books/shadow_of_the_wind.png", "9780978000012", 2001, "A boy discovers a mysterious book and is drawn into a decades-old secret in Barcelona." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AuthorId", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 3, 8, "/images/books/angels_game.png", "9780978000013", 2008, "A young writer strikes a dangerous deal with a mysterious publisher." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 3, 8, "9780978000014", 2011, "A stranger's visit reopens old wounds tied to the Cemetery of Forgotten Books." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "English", 8, "9780978000015", 2016, "The concluding novel of the Cemetery of Forgotten Books series." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookLanguage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { "Arabic", "9780978000016", 1993, "A painter recalls a lost love against the backdrop of Algeria's history." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "Summary" },
                values: new object[] { 4, "Arabic", 4, "/images/books/chaos_of_the_senses.png", "9780978000017", "A writer blurs the line between her fiction and her own life." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 4, 4, "9780978000018", 2003, "The concluding novel of the Memory in the Flesh trilogy." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 4, "Arabic", 4, "/images/books/black_suits_you.png", "9780978000019", 2012, "A singer's fame collides with grief and a complicated love." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "CoverImage", "ISBN", "PublishedYear", "Summary" },
                values: new object[] { 5, "Arabic", 4, "/images/books/i_am_free.png", "9780978000020", 1954, "A young woman pushes back against family and social expectations." });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AuthorId", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 5, 4, "9780978000021", 1959, "A story of love and loyalty tested by circumstance.", "Don't Let the Sun Put It Out" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 5, "Arabic", 4, "9780978000022", 1955, "A young woman's private reflections on love and independence.", "A Girl's Diary" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AuthorId", "BookLanguage", "CategoryId", "ISBN", "PublishedYear", "Summary", "Title" },
                values: new object[] { 5, "Arabic", 4, "9780978000023", 1957, "A family drama about jealousy and control across generations.", "I Do Not Sleep" });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "DueDate", "RequestDate" },
                values: new object[] { new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "DueDate", "RequestDate" },
                values: new object[] { new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookCopyId", "BorrowDate", "DueDate", "RequestDate", "Status" },
                values: new object[] { 13, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookCopyId", "Status" },
                values: new object[] { 23, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MembershipStartDate",
                value: new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                column: "MembershipStartDate",
                value: new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "mostafa.adel@example.com", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122201", "mostafa_adel" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "farida.hassan@example.com", new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122202", "farida.hassan" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "ahmed.tarek@example.com", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122203", "ahmed.tarek" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "mona.saeed@example.com", new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122204", "mona_saeed" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "youssef.k@example.com", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122205", "youssef.k" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "nourhan.ali@example.com", new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122206", "nourhan.ali" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "karim.mostafa@example.com", new DateTime(2026, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122207", "karim.mostafa" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "salma.ibrahim@example.com", new DateTime(2027, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122208", "salma.ibrahim" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "hassan.fouad@example.com", new DateTime(2027, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122209", "hassan.fouad" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "dina.mahmoud@example.com", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122210", "dina.mahmoud" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "amr.samir@example.com", new DateTime(2027, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122211", "amr.samir" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "yasmin.adel@example.com", new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122212", "yasmin.adel" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "tarek.nabil@example.com", new DateTime(2027, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122213", "tarek.nabil" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "rania.mostafa@example.com", new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122214", "rania.mostafa" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "mohamed.essam@example.com", new DateTime(2027, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122215", "mohamed.essam" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "heba.khaled@example.com", new DateTime(2027, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122216", "heba.khaled" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "ali.hassan@example.com", new DateTime(2027, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122217", "ali.hassan" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Email", "IsBlocked", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "mariam.said@example.com", true, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122218", "mariam.said" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "khaled.omar@example.com", new DateTime(2027, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122219", "khaled.omar" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Email", "MembershipExpiryDate", "MembershipStartDate", "PhoneNumber", "UserName" },
                values: new object[] { "nada.fathy@example.com", new DateTime(2027, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011122220", "nada.fathy" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { "A vivid portrait of Cairo life, still feels alive today.", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 7, "Magical and unforgettable, unlike anything else I've read.", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 12, "Beautifully atmospheric mystery set in Barcelona.", new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 17, "Poetic and deeply moving, hard to put down.", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookId", "Comment", "CreatedDate", "MemberId", "Rating" },
                values: new object[] { 20, "A powerful story about independence and self-respect.", new DateTime(2026, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4 });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_BookId",
                table: "Reservations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Members_MemberId",
                table: "Reservations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
