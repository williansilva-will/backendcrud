using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud_Core.Migrations
{
    public partial class CriarBancoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(16)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Sobre_Nome = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DT_Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
