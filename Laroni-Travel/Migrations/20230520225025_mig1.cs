using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laroni_Travel.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestemmingen",
                columns: table => new
                {
                    BestemmingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straatnaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestemmingen", x => x.BestemmingId);
                });

            migrationBuilder.CreateTable(
                name: "LeeftijdsCategorieen",
                columns: table => new
                {
                    LeeftijdsCategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeeftijdsCategorieen", x => x.LeeftijdsCategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Opleidingen",
                columns: table => new
                {
                    OpleidingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opleidingen", x => x.OpleidingId);
                });

            migrationBuilder.CreateTable(
                name: "Rolen",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolen", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Themas",
                columns: table => new
                {
                    ThemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themas", x => x.ThemaId);
                });

            migrationBuilder.CreateTable(
                name: "Deelnemers",
                columns: table => new
                {
                    DeelnemerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familienaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geslacht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoofdMonitor = table.Column<bool>(type: "bit", nullable: false),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monitor = table.Column<bool>(type: "bit", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Straatnaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ziekenfonds = table.Column<bool>(type: "bit", nullable: false),
                    BestemmingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deelnemers", x => x.DeelnemerId);
                    table.ForeignKey(
                        name: "FK_Deelnemers_Bestemmingen_BestemmingId",
                        column: x => x.BestemmingId,
                        principalTable: "Bestemmingen",
                        principalColumn: "BestemmingId");
                });

            migrationBuilder.CreateTable(
                name: "OpleidingBestemmingen",
                columns: table => new
                {
                    OpleidingBestemmingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpleidingId = table.Column<int>(type: "int", nullable: false),
                    BestemmingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpleidingBestemmingen", x => x.OpleidingBestemmingId);
                    table.ForeignKey(
                        name: "FK_OpleidingBestemmingen_Bestemmingen_BestemmingId",
                        column: x => x.BestemmingId,
                        principalTable: "Bestemmingen",
                        principalColumn: "BestemmingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpleidingBestemmingen_Opleidingen_OpleidingId",
                        column: x => x.OpleidingId,
                        principalTable: "Opleidingen",
                        principalColumn: "OpleidingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groepsreisen",
                columns: table => new
                {
                    GroepsreisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestemmingId = table.Column<int>(type: "int", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeeftijdsCategorieId = table.Column<int>(type: "int", nullable: false),
                    Prijs = table.Column<decimal>(type: "money", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groepsreisen", x => x.GroepsreisId);
                    table.ForeignKey(
                        name: "FK_Groepsreisen_Bestemmingen_BestemmingId",
                        column: x => x.BestemmingId,
                        principalTable: "Bestemmingen",
                        principalColumn: "BestemmingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groepsreisen_LeeftijdsCategorieen_LeeftijdsCategorieId",
                        column: x => x.LeeftijdsCategorieId,
                        principalTable: "LeeftijdsCategorieen",
                        principalColumn: "LeeftijdsCategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groepsreisen_Themas_ThemaId",
                        column: x => x.ThemaId,
                        principalTable: "Themas",
                        principalColumn: "ThemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeelnemerOpleidingen",
                columns: table => new
                {
                    DeelnemerOpleidingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeelnemerId = table.Column<int>(type: "int", nullable: false),
                    OpleidingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeelnemerOpleidingen", x => x.DeelnemerOpleidingId);
                    table.ForeignKey(
                        name: "FK_DeelnemerOpleidingen_Deelnemers_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Deelnemers",
                        principalColumn: "DeelnemerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeelnemerOpleidingen_Opleidingen_OpleidingId",
                        column: x => x.OpleidingId,
                        principalTable: "Opleidingen",
                        principalColumn: "OpleidingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medische",
                columns: table => new
                {
                    MedischId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeelnemerId = table.Column<int>(type: "int", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Behandeling = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medische", x => x.MedischId);
                    table.ForeignKey(
                        name: "FK_Medische_Deelnemers_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Deelnemers",
                        principalColumn: "DeelnemerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeelnemerGroepsreisen",
                columns: table => new
                {
                    DeelnemerGroepsreisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeelnemerId = table.Column<int>(type: "int", nullable: false),
                    GroepsreisId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeelnemerGroepsreisen", x => x.DeelnemerGroepsreisId);
                    table.ForeignKey(
                        name: "FK_DeelnemerGroepsreisen_Deelnemers_DeelnemerId",
                        column: x => x.DeelnemerId,
                        principalTable: "Deelnemers",
                        principalColumn: "DeelnemerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeelnemerGroepsreisen_Groepsreisen_GroepsreisId",
                        column: x => x.GroepsreisId,
                        principalTable: "Groepsreisen",
                        principalColumn: "GroepsreisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeelnemerGroepsreisen_Rolen_RolId",
                        column: x => x.RolId,
                        principalTable: "Rolen",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerGroepsreisen_DeelnemerId",
                table: "DeelnemerGroepsreisen",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerGroepsreisen_GroepsreisId",
                table: "DeelnemerGroepsreisen",
                column: "GroepsreisId");

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerGroepsreisen_RolId",
                table: "DeelnemerGroepsreisen",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerOpleidingen_DeelnemerId",
                table: "DeelnemerOpleidingen",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeelnemerOpleidingen_OpleidingId",
                table: "DeelnemerOpleidingen",
                column: "OpleidingId");

            migrationBuilder.CreateIndex(
                name: "IX_Deelnemers_BestemmingId",
                table: "Deelnemers",
                column: "BestemmingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreisen_BestemmingId",
                table: "Groepsreisen",
                column: "BestemmingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreisen_LeeftijdsCategorieId",
                table: "Groepsreisen",
                column: "LeeftijdsCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Groepsreisen_ThemaId",
                table: "Groepsreisen",
                column: "ThemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medische_DeelnemerId",
                table: "Medische",
                column: "DeelnemerId");

            migrationBuilder.CreateIndex(
                name: "IX_OpleidingBestemmingen_BestemmingId",
                table: "OpleidingBestemmingen",
                column: "BestemmingId");

            migrationBuilder.CreateIndex(
                name: "IX_OpleidingBestemmingen_OpleidingId",
                table: "OpleidingBestemmingen",
                column: "OpleidingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeelnemerGroepsreisen");

            migrationBuilder.DropTable(
                name: "DeelnemerOpleidingen");

            migrationBuilder.DropTable(
                name: "Medische");

            migrationBuilder.DropTable(
                name: "OpleidingBestemmingen");

            migrationBuilder.DropTable(
                name: "Groepsreisen");

            migrationBuilder.DropTable(
                name: "Rolen");

            migrationBuilder.DropTable(
                name: "Deelnemers");

            migrationBuilder.DropTable(
                name: "Opleidingen");

            migrationBuilder.DropTable(
                name: "LeeftijdsCategorieen");

            migrationBuilder.DropTable(
                name: "Themas");

            migrationBuilder.DropTable(
                name: "Bestemmingen");
        }
    }
}
