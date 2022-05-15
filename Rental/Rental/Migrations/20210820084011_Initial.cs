using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    IDKategorija = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__7E48B6E5F7D0FE93", x => x.IDKategorija);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    IDKlijent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EMail = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Klijent__0769C703201E9FEA", x => x.IDKlijent);
                });

            migrationBuilder.CreateTable(
                name: "Mjesto",
                columns: table => new
                {
                    IDMjesto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mjesto__2CC2E480547B6EB9", x => x.IDMjesto);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    IDNacinPlacanja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NacinPla__D431C3C9F34CB413", x => x.IDNacinPlacanja);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    IDVozilo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    kategorija = table.Column<int>(nullable: false),
                    Cijena = table.Column<int>(nullable: false),
                    Dostupan = table.Column<bool>(nullable: false),
                    Registracija = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vozilo__2A0736848F114D28", x => x.IDVozilo);
                    table.ForeignKey(
                        name: "FK__Vozilo__kategori__2B3F6F97",
                        column: x => x.kategorija,
                        principalTable: "Kategorija",
                        principalColumn: "IDKategorija",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    IDRezervacija = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOd = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime", nullable: false),
                    MjestoPreuzimanja = table.Column<int>(nullable: false),
                    MjestoPovrata = table.Column<int>(nullable: false),
                    Vozilo = table.Column<int>(nullable: false),
                    Klijent = table.Column<int>(nullable: false),
                    Nacin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rezervac__21D11B290805B468", x => x.IDRezervacija);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Klije__30F848ED",
                        column: x => x.Klijent,
                        principalTable: "Klijent",
                        principalColumn: "IDKlijent",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Mjest__2F10007B",
                        column: x => x.MjestoPovrata,
                        principalTable: "Mjesto",
                        principalColumn: "IDMjesto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Mjest__2E1BDC42",
                        column: x => x.MjestoPreuzimanja,
                        principalTable: "Mjesto",
                        principalColumn: "IDMjesto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Nacin__31EC6D26",
                        column: x => x.Nacin,
                        principalTable: "NacinPlacanja",
                        principalColumn: "IDNacinPlacanja",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Vozil__300424B4",
                        column: x => x.Vozilo,
                        principalTable: "Vozilo",
                        principalColumn: "IDVozilo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_Klijent",
                table: "Rezervacija",
                column: "Klijent");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_MjestoPovrata",
                table: "Rezervacija",
                column: "MjestoPovrata");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_MjestoPreuzimanja",
                table: "Rezervacija",
                column: "MjestoPreuzimanja");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_Nacin",
                table: "Rezervacija",
                column: "Nacin");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_Vozilo",
                table: "Rezervacija",
                column: "Vozilo");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_kategorija",
                table: "Vozilo",
                column: "kategorija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Mjesto");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
