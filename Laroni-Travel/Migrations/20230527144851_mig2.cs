using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laroni_Travel.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxAantalDeelenemrs",
                table: "Opleidingen",
                newName: "MaxAantalDeelnemers");

            migrationBuilder.RenameColumn(
                name: "MaxAantalDeelenemrs",
                table: "Groepsreisen",
                newName: "MaxAantalDeelnemers");

            migrationBuilder.AddColumn<string>(
                name: "Wachtwoord",
                table: "Deelnemers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Betaald",
                table: "DeelnemerGroepsreisen",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wachtwoord",
                table: "Deelnemers");

            migrationBuilder.DropColumn(
                name: "Betaald",
                table: "DeelnemerGroepsreisen");

            migrationBuilder.RenameColumn(
                name: "MaxAantalDeelnemers",
                table: "Opleidingen",
                newName: "MaxAantalDeelenemrs");

            migrationBuilder.RenameColumn(
                name: "MaxAantalDeelnemers",
                table: "Groepsreisen",
                newName: "MaxAantalDeelenemrs");
        }
    }
}
