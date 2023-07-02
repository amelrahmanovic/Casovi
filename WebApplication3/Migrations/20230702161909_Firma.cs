using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Firma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmaId",
                table: "Osoba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaPK);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_FirmaId",
                table: "Osoba",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Osoba_Firma_FirmaId",
                table: "Osoba",
                column: "FirmaId",
                principalTable: "Firma",
                principalColumn: "FirmaPK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osoba_Firma_FirmaId",
                table: "Osoba");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_Osoba_FirmaId",
                table: "Osoba");

            migrationBuilder.DropColumn(
                name: "FirmaId",
                table: "Osoba");
        }
    }
}
