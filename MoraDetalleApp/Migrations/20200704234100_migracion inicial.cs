using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoraDetalleApp.Migrations
{
    public partial class migracioninicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    MoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.MoraId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Persona = table.Column<string>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "MoraDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_Prestamos_MoraId",
                        column: x => x.MoraId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Moras",
                columns: new[] { "MoraId", "Fecha", "Valor" },
                values: new object[] { 1, new DateTime(2020, 7, 4, 19, 40, 59, 924, DateTimeKind.Local).AddTicks(3659), 5000.0 });

            migrationBuilder.InsertData(
                table: "Moras",
                columns: new[] { "MoraId", "Fecha", "Valor" },
                values: new object[] { 2, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000.0 });

            migrationBuilder.InsertData(
                table: "Moras",
                columns: new[] { "MoraId", "Fecha", "Valor" },
                values: new object[] { 3, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_MoraId",
                table: "MoraDetalle",
                column: "MoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoraDetalle");

            migrationBuilder.DropTable(
                name: "Moras");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
