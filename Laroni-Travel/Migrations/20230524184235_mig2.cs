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
            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleidingen_Deelnemers_DeelnemerId",
                table: "DeelnemerOpleidingen");

            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleidingen_Opleidingen_OpleidingId",
                table: "DeelnemerOpleidingen");

            migrationBuilder.DropForeignKey(
                name: "FK_OpleidingBestemmingen_Bestemmingen_BestemmingId",
                table: "OpleidingBestemmingen");

            migrationBuilder.DropForeignKey(
                name: "FK_OpleidingBestemmingen_Opleidingen_OpleidingId",
                table: "OpleidingBestemmingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpleidingBestemmingen",
                table: "OpleidingBestemmingen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeelnemerOpleidingen",
                table: "DeelnemerOpleidingen");

            migrationBuilder.RenameTable(
                name: "OpleidingBestemmingen",
                newName: "OpleidingBestemming");

            migrationBuilder.RenameTable(
                name: "DeelnemerOpleidingen",
                newName: "DeelnemerOpleiding");

            migrationBuilder.RenameIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemming",
                newName: "IX_OpleidingBestemming_OpleidingId");

            migrationBuilder.RenameIndex(
                name: "IX_OpleidingBestemmingen_BestemmingId",
                table: "OpleidingBestemming",
                newName: "IX_OpleidingBestemming_BestemmingId");

            migrationBuilder.RenameIndex(
                name: "IX_DeelnemerOpleidingen_OpleidingId",
                table: "DeelnemerOpleiding",
                newName: "IX_DeelnemerOpleiding_OpleidingId");

            migrationBuilder.RenameIndex(
                name: "IX_DeelnemerOpleidingen_DeelnemerId",
                table: "DeelnemerOpleiding",
                newName: "IX_DeelnemerOpleiding_DeelnemerId");

            migrationBuilder.AddColumn<int>(
                name: "BestemmingId",
                table: "DeelnemerOpleiding",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpleidingBestemming",
                table: "OpleidingBestemming",
                column: "OpleidingBestemmingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeelnemerOpleiding",
                table: "DeelnemerOpleiding",
                column: "DeelnemerOpleidingId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DeelnemerOpleiding_Deelnemers_DeelnemerId",
                table: "DeelnemerOpleiding",
                column: "DeelnemerId",
                principalTable: "Deelnemers",
                principalColumn: "DeelnemerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeelnemerOpleiding_Opleidingen_OpleidingId",
                table: "DeelnemerOpleiding",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "OpleidingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpleidingBestemming_Bestemmingen_BestemmingId",
                table: "OpleidingBestemming",
                column: "BestemmingId",
                principalTable: "Bestemmingen",
                principalColumn: "BestemmingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpleidingBestemming_Opleidingen_OpleidingId",
                table: "OpleidingBestemming",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "OpleidingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleiding_Bestemmingen_BestemmingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleiding_Deelnemers_DeelnemerId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropForeignKey(
                name: "FK_DeelnemerOpleiding_Opleidingen_OpleidingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropForeignKey(
                name: "FK_OpleidingBestemming_Bestemmingen_BestemmingId",
                table: "OpleidingBestemming");

            migrationBuilder.DropForeignKey(
                name: "FK_OpleidingBestemming_Opleidingen_OpleidingId",
                table: "OpleidingBestemming");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpleidingBestemming",
                table: "OpleidingBestemming");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeelnemerOpleiding",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropIndex(
                name: "IX_DeelnemerOpleiding_BestemmingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.DropColumn(
                name: "BestemmingId",
                table: "DeelnemerOpleiding");

            migrationBuilder.RenameTable(
                name: "OpleidingBestemming",
                newName: "OpleidingBestemmingen");

            migrationBuilder.RenameTable(
                name: "DeelnemerOpleiding",
                newName: "DeelnemerOpleidingen");

            migrationBuilder.RenameIndex(
                name: "IX_OpleidingBestemming_OpleidingId",
                table: "OpleidingBestemmingen",
                newName: "IX_OpleidingBestemmingen_OpleidingId");

            migrationBuilder.RenameIndex(
                name: "IX_OpleidingBestemming_BestemmingId",
                table: "OpleidingBestemmingen",
                newName: "IX_OpleidingBestemmingen_BestemmingId");

            migrationBuilder.RenameIndex(
                name: "IX_DeelnemerOpleiding_OpleidingId",
                table: "DeelnemerOpleidingen",
                newName: "IX_DeelnemerOpleidingen_OpleidingId");

            migrationBuilder.RenameIndex(
                name: "IX_DeelnemerOpleiding_DeelnemerId",
                table: "DeelnemerOpleidingen",
                newName: "IX_DeelnemerOpleidingen_DeelnemerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpleidingBestemmingen",
                table: "OpleidingBestemmingen",
                column: "OpleidingBestemmingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeelnemerOpleidingen",
                table: "DeelnemerOpleidingen",
                column: "DeelnemerOpleidingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeelnemerOpleidingen_Deelnemers_DeelnemerId",
                table: "DeelnemerOpleidingen",
                column: "DeelnemerId",
                principalTable: "Deelnemers",
                principalColumn: "DeelnemerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeelnemerOpleidingen_Opleidingen_OpleidingId",
                table: "DeelnemerOpleidingen",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "OpleidingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpleidingBestemmingen_Bestemmingen_BestemmingId",
                table: "OpleidingBestemmingen",
                column: "BestemmingId",
                principalTable: "Bestemmingen",
                principalColumn: "BestemmingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OpleidingBestemmingen_Opleidingen_OpleidingId",
                table: "OpleidingBestemmingen",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "OpleidingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
