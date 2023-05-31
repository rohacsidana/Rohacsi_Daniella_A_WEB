using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vizsga_alap_backend.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategorianev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    timestamps = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__kategori__3213E83F99093144", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teszt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kerdes = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    v1 = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    v2 = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    v3 = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    v4 = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    helyes = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    kategoriaId = table.Column<int>(type: "int", nullable: false),
                    timestamps = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__teszt__3213E83F12B8AC52", x => x.id);
                    table.ForeignKey(
                        name: "FK__teszt__timestamp__3A81B327",
                        column: x => x.kategoriaId,
                        principalTable: "kategoria",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_teszt_kategoriaId",
                table: "teszt",
                column: "kategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teszt");

            migrationBuilder.DropTable(
                name: "kategoria");
        }
    }
}
