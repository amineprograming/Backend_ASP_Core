using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class DeleteRelationReceptionFournisseur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_fournisseur_idFournisseur",
                table: "reception");

            migrationBuilder.DropIndex(
                name: "IX_reception_idFournisseur",
                table: "reception");

            migrationBuilder.DropColumn(
                name: "idFournisseur",
                table: "reception");

            migrationBuilder.AddColumn<int>(
                name: "FournisseurId",
                table: "article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_article_FournisseurId",
                table: "article",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_article_fournisseur_FournisseurId",
                table: "article",
                column: "FournisseurId",
                principalTable: "fournisseur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_article_fournisseur_FournisseurId",
                table: "article");

            migrationBuilder.DropIndex(
                name: "IX_article_FournisseurId",
                table: "article");

            migrationBuilder.DropColumn(
                name: "FournisseurId",
                table: "article");

            migrationBuilder.AddColumn<int>(
                name: "idFournisseur",
                table: "reception",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reception_idFournisseur",
                table: "reception",
                column: "idFournisseur");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_fournisseur_idFournisseur",
                table: "reception",
                column: "idFournisseur",
                principalTable: "fournisseur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
