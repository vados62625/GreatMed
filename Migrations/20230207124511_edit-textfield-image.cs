using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoHelp.Migrations
{
    /// <inheritdoc />
    public partial class edittextfieldimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleImagePath",
                table: "TextFields");

            migrationBuilder.AddColumn<int>(
                name: "TitlePictireId",
                table: "TextFields",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ad6e2a4-f17f-4b05-bcfd-9f799bd8cf2c", "AQAAAAIAAYagAAAAEK6yXOwJiUv/13bzUmwK7r82t+wSZuJih+l9d91wlebMVeSRbLd3T7QUZn/04T6Ftw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "TitlePictireId" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 45, 11, 112, DateTimeKind.Utc).AddTicks(2189), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "TitlePictireId" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 45, 11, 112, DateTimeKind.Utc).AddTicks(2146), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                columns: new[] { "DateAdded", "TitlePictireId" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 45, 11, 112, DateTimeKind.Utc).AddTicks(2197), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "TitlePictireId" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 45, 11, 112, DateTimeKind.Utc).AddTicks(2179), null });

            migrationBuilder.CreateIndex(
                name: "IX_TextFields_TitlePictireId",
                table: "TextFields",
                column: "TitlePictireId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextFields_ImageUri_TitlePictireId",
                table: "TextFields",
                column: "TitlePictireId",
                principalTable: "ImageUri",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextFields_ImageUri_TitlePictireId",
                table: "TextFields");

            migrationBuilder.DropIndex(
                name: "IX_TextFields_TitlePictireId",
                table: "TextFields");

            migrationBuilder.DropColumn(
                name: "TitlePictireId",
                table: "TextFields");

            migrationBuilder.AddColumn<string>(
                name: "TitleImagePath",
                table: "TextFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94b6a983-3036-4c9b-9f12-896cc454bf47", "AQAAAAIAAYagAAAAEBjaNBA9plQdykxJquKiMxT3vHWNCz+wTUgKY7Xf0PbXbiwi3C+x7JTk66vCUL3k3Q==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                columns: new[] { "DateAdded", "TitleImagePath" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9867), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                columns: new[] { "DateAdded", "TitleImagePath" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9822), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                columns: new[] { "DateAdded", "TitleImagePath" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9876), null });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                columns: new[] { "DateAdded", "TitleImagePath" },
                values: new object[] { new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9857), null });
        }
    }
}
