using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MichalDzialekLab7_ZadDom.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Typy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Przedmioty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: false),
                    KategoriaID = table.Column<int>(nullable: false),
                    TypID = table.Column<int>(nullable: false),
                    RodzajID = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 12, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przedmioty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Przedmioty_Kategorie_KategoriaID",
                        column: x => x.KategoriaID,
                        principalTable: "Kategorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Przedmioty_Rodzaje_RodzajID",
                        column: x => x.RodzajID,
                        principalTable: "Rodzaje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Przedmioty_Typy_TypID",
                        column: x => x.TypID,
                        principalTable: "Typy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Przedmioty_KategoriaID",
                table: "Przedmioty",
                column: "KategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Przedmioty_RodzajID",
                table: "Przedmioty",
                column: "RodzajID");

            migrationBuilder.CreateIndex(
                name: "IX_Przedmioty_TypID",
                table: "Przedmioty",
                column: "TypID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przedmioty");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Rodzaje");

            migrationBuilder.DropTable(
                name: "Typy");
        }
    }
}
