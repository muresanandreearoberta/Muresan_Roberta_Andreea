using Microsoft.EntityFrameworkCore.Migrations;

namespace Muresan_Roberta_Andreea.Migrations
{
    public partial class MeniuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Meniu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MeniuCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeniuID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeniuCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MeniuCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeniuCategory_Meniu_MeniuID",
                        column: x => x.MeniuID,
                        principalTable: "Meniu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meniu_CategorieID",
                table: "Meniu",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_MeniuCategory_CategoryID",
                table: "MeniuCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MeniuCategory_MeniuID",
                table: "MeniuCategory",
                column: "MeniuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meniu_Categorie_CategorieID",
                table: "Meniu",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meniu_Categorie_CategorieID",
                table: "Meniu");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "MeniuCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Meniu_CategorieID",
                table: "Meniu");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Meniu");
        }
    }
}
