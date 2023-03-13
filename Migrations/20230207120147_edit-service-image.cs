using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoHelp.Migrations
{
    /// <inheritdoc />
    public partial class editserviceimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "MHService");

            migrationBuilder.AddColumn<int>(
                name: "TitlePictireId",
                table: "MHService",
                type: "int",
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
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9867));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 12, 1, 47, 775, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.CreateIndex(
                name: "IX_MHService_TitlePictireId",
                table: "MHService",
                column: "TitlePictireId");

            migrationBuilder.AddForeignKey(
                name: "FK_MHService_ImageUri_TitlePictireId",
                table: "MHService",
                column: "TitlePictireId",
                principalTable: "ImageUri",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MHService_ImageUri_TitlePictireId",
                table: "MHService");

            migrationBuilder.DropIndex(
                name: "IX_MHService_TitlePictireId",
                table: "MHService");

            migrationBuilder.DropColumn(
                name: "TitlePictireId",
                table: "MHService");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "MHService",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "51f492c9-2bb2-49d5-8da4-e399e4b56d0f", "AQAAAAIAAYagAAAAEAAu9gfhaafanY+VWklLT4y9Rxe5RTM48VIKT0u/kj3cP8bb+532uqllOmMuBg8NPw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 10, 20, 57, 272, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 10, 20, 57, 272, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 10, 20, 57, 272, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 7, 10, 20, 57, 272, DateTimeKind.Utc).AddTicks(1511));
        }
    }
}
