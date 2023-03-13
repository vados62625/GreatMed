using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoHelp.Migrations
{
    /// <inheritdoc />
    public partial class editimageuri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTitle",
                table: "ImageUri");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTitle",
                table: "ImageUri",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fa8005b-d3df-4b7c-86a2-0e97f9c39cfb", "AQAAAAIAAYagAAAAEL0sFLCHatgOsF5AY2AW8stb/uwsfcyCQKhXQdXlDJSAnQ8gEuTBENunyhXkja6iSQ==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("64de805e-a62a-11ed-afa1-0242ac120002"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 6, 14, 32, 58, 802, DateTimeKind.Utc).AddTicks(7568));
        }
    }
}
