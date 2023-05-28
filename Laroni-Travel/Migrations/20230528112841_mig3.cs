using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laroni_Travel.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemmingen");

            migrationBuilder.AlterColumn<string>(
                name: "Wachtwoord",
                table: "Deelnemers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemmingen",
                column: "OpleidingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemmingen");

            migrationBuilder.AlterColumn<string>(
                name: "Wachtwoord",
                table: "Deelnemers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemmingen",
                column: "OpleidingId");
        }
    }
}
