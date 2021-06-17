using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Catalogo.API.Migrations
{
    public partial class campoEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "QuantidadeEstoque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeEstoque",
                table: "Produtos",
                newName: "Quantidade");
        }
    }
}
