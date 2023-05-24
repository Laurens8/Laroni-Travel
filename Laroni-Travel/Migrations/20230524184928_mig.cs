using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laroni_Travel.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleiding_Bestemmingen_BestemmingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropIndex(
                name: "IX_DeelnemerOpleiding_BestemmingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropColumn(
                name: "BestemmingId",
                table: "DeelnemerOpleiding");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestemmingId",
                table: "DeelnemerOpleiding",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerOpleiding_BestemmingId",
                table: "DeelnemerOpleiding",
                column: "BestemmingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeelnemerOpleiding_Bestemmingen_BestemmingId",
                table: "DeelnemerOpleiding",
                column: "BestemmingId",
                principalTable: "Bestemmingen",
                principalColumn: "BestemmingId");
        }
    }
}
