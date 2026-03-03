using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeStore.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerfumeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfumeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PerfumeCategoryId = table.Column<int>(type: "int", nullable: false),
                    PerfumeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfumes_PerfumeCategories_PerfumeCategoryId",
                        column: x => x.PerfumeCategoryId,
                        principalTable: "PerfumeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perfumes_PerfumeTypes_PerfumeTypeId",
                        column: x => x.PerfumeTypeId,
                        principalTable: "PerfumeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeCategoryId",
                table: "Perfumes",
                column: "PerfumeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeTypeId",
                table: "Perfumes",
                column: "PerfumeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfumes");

            migrationBuilder.DropTable(
                name: "PerfumeCategories");

            migrationBuilder.DropTable(
                name: "PerfumeTypes");
        }
    }
}
