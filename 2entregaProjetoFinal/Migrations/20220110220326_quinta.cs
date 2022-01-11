using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2entregaProjetoFinal.Migrations
{
    public partial class quinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "avaliacoes",
                newName: "Comentario");

            migrationBuilder.AlterColumn<float>(
                name: "NotaEstabelecimento",
                table: "estabelecimentos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "NotaEstabelecimento",
                table: "avaliacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_avaliacoes_IdUsuario",
                table: "avaliacoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_avaliacoes_usuarios_IdUsuario",
                table: "avaliacoes",
                column: "IdUsuario",
                principalTable: "usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_avaliacoes_usuarios_IdUsuario",
                table: "avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_avaliacoes_IdUsuario",
                table: "avaliacoes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "avaliacoes");

            migrationBuilder.DropColumn(
                name: "NotaEstabelecimento",
                table: "avaliacoes");

            migrationBuilder.RenameColumn(
                name: "Comentario",
                table: "avaliacoes",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "NotaEstabelecimento",
                table: "estabelecimentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
