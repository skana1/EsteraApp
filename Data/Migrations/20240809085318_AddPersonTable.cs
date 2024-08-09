using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteraApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nid = table.Column<int>(type: "nvarchar(max)", nullable: false),
                    Emer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mbiemer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Atesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gjinia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datelindja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vendlindja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
