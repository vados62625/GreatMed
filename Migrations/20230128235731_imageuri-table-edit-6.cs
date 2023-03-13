using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoHelp.Migrations
{
    /// <inheritdoc />
    public partial class imageuritableedit6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MHCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestedCall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestedCall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MHDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InStock = table.Column<long>(type: "bigint", nullable: true),
                    MHCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MHDetail_MHCategory_MHCategoryId",
                        column: x => x.MHCategoryId,
                        principalTable: "MHCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageUri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalMHDetailId = table.Column<int>(type: "int", nullable: true),
                    TitleMHDetailId = table.Column<int>(type: "int", nullable: true),
                    IsTitle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUri_MHDetail_AdditionalMHDetailId",
                        column: x => x.AdditionalMHDetailId,
                        principalTable: "MHDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageUri_MHDetail_TitleMHDetailId",
                        column: x => x.TitleMHDetailId,
                        principalTable: "MHDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageUri_AdditionalMHDetailId",
                table: "ImageUri",
                column: "AdditionalMHDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUri_TitleMHDetailId",
                table: "ImageUri",
                column: "TitleMHDetailId",
                unique: true,
                filter: "[TitleMHDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MHDetail_MHCategoryId",
                table: "MHDetail",
                column: "MHCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUri");

            migrationBuilder.DropTable(
                name: "MHService");

            migrationBuilder.DropTable(
                name: "RequestedCall");

            migrationBuilder.DropTable(
                name: "MHDetail");

            migrationBuilder.DropTable(
                name: "MHCategory");
        }
    }
}
