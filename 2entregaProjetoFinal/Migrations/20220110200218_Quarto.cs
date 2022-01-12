using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2entregaProjetoFinal.Migrations
{
    public partial class Quarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirme_Senha",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "Nome_Social",
                table: "usuarios",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuarios",
                newName: "NomeUsuario");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuarios",
                newName: "NessecidadeEspecial");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "usuarios",
                newName: "IdUsuario");

            migrationBuilder.CreateTable(
                name: "estabelecimentos",
                columns: table => new
                {
                    IdEstabelecimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstabelecimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotaEstabelecimento = table.Column<int>(type: "int", nullable: false),
                    HorarioFuncionamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComentariosEstabelecimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcessibilidadesEstabelecimentos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estabelecimentos", x => x.IdEstabelecimento);
                });

            migrationBuilder.CreateTable(
                name: "avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstabelecimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacoes", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_avaliacoes_estabelecimentos_IdEstabelecimento",
                        column: x => x.IdEstabelecimento,
                        principalTable: "estabelecimentos",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avaliacoes_IdEstabelecimento",
                table: "avaliacoes",
                column: "IdEstabelecimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacoes");

            migrationBuilder.DropTable(
                name: "estabelecimentos");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "usuarios",
                newName: "Nome_Social");

            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "NessecidadeEspecial",
                table: "usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "usuarios",
                newName: "Id_Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Confirme_Senha",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
