using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investimentos.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtivosRendaVariavel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoRendaVariavel = table.Column<int>(nullable: false),
                    NomePregao = table.Column<string>(maxLength: 100, nullable: false),
                    CodigoNegociacao = table.Column<string>(maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    Site = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivosRendaVariavel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivosRendaVariavel");
        }
    }
}
