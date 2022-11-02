using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reception",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateReception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idFournisseur = table.Column<int>(type: "int", nullable: false),
                    HT = table.Column<double>(type: "float", nullable: false),
                    TVA = table.Column<double>(type: "float", nullable: false),
                    TTC = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reception_fournisseur_idFournisseur",
                        column: x => x.idFournisseur,
                        principalTable: "fournisseur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsReception",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qte = table.Column<int>(type: "int", nullable: false),
                    PrixHt = table.Column<double>(type: "float", nullable: false),
                    TVA = table.Column<double>(type: "float", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ReceptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsReception", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsReception_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsReception_reception_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "reception",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReception_ArticleId",
                table: "DetailsReception",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReception_ReceptionId",
                table: "DetailsReception",
                column: "ReceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_reception_idFournisseur",
                table: "reception",
                column: "idFournisseur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsReception");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "reception");

            migrationBuilder.DropTable(
                name: "fournisseur");
        }
    }
}
