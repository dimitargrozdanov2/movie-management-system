using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManagement.Data.Migrations
{
    public partial class JsonAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "JeffGoldblum" },
                    { 2, "ChrisEvans" },
                    { 3, "ScarlettJohansson" },
                    { 4, "SandraBullock" },
                    { 5, "JohnnyDepp" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e78767e-b4d2-456f-b029-5ad4c454589a", "6e63ab39-a514-4e99-ba86-296cfe8d15b5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b8ddcfb-ef03-487b-affb-766611dc9e17", 0, "b318fa87-5d53-4bc3-8019-23d7aa37da20", "admin@admin.admin", false, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", "AQAAAAEAACcQAAAAEHzP/Ds0oHiv5C7IjlaA+ce9X9hucPveVIL0EgYgT7ScxgYCFnZFsMQQZLRC5BPKLw==", null, false, "7I2NUNAXILZUAHNGX7TRSNQCNRWCEOSX", false, "admin" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Psycho" },
                    { 3, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "DatePosted", "Text", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 8, 5, 12, 56, 511, DateTimeKind.Utc), "This year will mark the last Avengers movie", "Avengers" },
                    { 2, new DateTime(2012, 12, 21, 12, 0, 56, 511, DateTimeKind.Utc), "According to Maya's people today will be the day the world ends. There will be no more movies", "WorldEnds" },
                    { 3, new DateTime(2018, 11, 12, 4, 13, 56, 511, DateTimeKind.Utc), "Manchester lost to Barca on Old Trafford.", "ManchesterLost" },
                    { 4, new DateTime(2019, 4, 10, 23, 52, 56, 511, DateTimeKind.Utc), "Tickets have been soldout for the premirer of Shazam", "TicketsSoldout" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0b8ddcfb-ef03-487b-affb-766611dc9e17", "0e78767e-b4d2-456f-b029-5ad4c454589a" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Director", "Duration", "GenreID", "IsDeleted", "Name", "Rating", "Storyline", "VotesCount" },
                values: new object[,]
                {
                    { 2, "Guy Ritchie", 120, 1, false, "Aladdin", 0.0, "A kindhearted Arabian street urchin and a power-hungry Grand Vizier vie for a magic lamp that has the power to make the deepest wishes come true.", 0 },
                    { 1, "Anna Boden", 90, 2, false, "Marvel", 0.0, "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.", 0 },
                    { 3, "Travis Knight", 90, 2, false, "Bumblebee", 0.0, "On the run in the year of 1987, Bumblebee finds refuge in a junkyard in a small Californian beach town. Charlie, on the cusp of turning 18 and trying to find her place in the world, discovers Bumblebee, battle-scarred and broken.", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0b8ddcfb-ef03-487b-affb-766611dc9e17", "0e78767e-b4d2-456f-b029-5ad4c454589a" });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e78767e-b4d2-456f-b029-5ad4c454589a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b8ddcfb-ef03-487b-affb-766611dc9e17");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
