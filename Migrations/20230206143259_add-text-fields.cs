using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotoHelp.Migrations
{
    /// <inheritdoc />
    public partial class addtextfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFields", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44546e06-8719-4ad8-b88a-f271ae9d6eab", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b62472e-4f66-49fa-a20f-e7685b9565d8", 0, "5fa8005b-d3df-4b7c-86a2-0e97f9c39cfb", "my@email.com", true, false, null, "MY@EMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEL0sFLCHatgOsF5AY2AW8stb/uwsfcyCQKhXQdXlDJSAnQ8gEuTBENunyhXkja6iSQ==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "Id", "DateAdded", "MetaDescription", "MetaTitle", "Name", "Subtitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"), new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7580), null, null, "PageAbout", null, "Содержание заполняется администратором", "О нас", null },
                    { new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"), new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7517), null, null, "PageIndex", null, "Содержание заполняется администратором", "Главная", null },
                    { new Guid("64de805e-a62a-11ed-afa1-0242ac120002"), new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7589), null, null, "PagePrivacy", null, "Содержание заполняется администратором", "Политика конфиденциальности", null },
                    { new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"), new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7568), null, null, "PageServices", null, "Содержание заполняется администратором", "Наши услуги", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "44546e06-8719-4ad8-b88a-f271ae9d6eab", "3b62472e-4f66-49fa-a20f-e7685b9565d8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextFields");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44546e06-8719-4ad8-b88a-f271ae9d6eab", "3b62472e-4f66-49fa-a20f-e7685b9565d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8");
        }
    }
}
