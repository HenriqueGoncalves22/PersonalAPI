using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoriosViolino");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "TB_VIOLINOS",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_VIOLINOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_ACESSORIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Materiais = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    TipoAcessorios = table.Column<int>(type: "int", nullable: false),
                    ViolinoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACESSORIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ACESSORIOS_TB_VIOLINOS_ViolinoId",
                        column: x => x.ViolinoId,
                        principalTable: "TB_VIOLINOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ACESSORIOS",
                columns: new[] { "Id", "Descricao", "Marca", "Materiais", "Modelo", "Nome", "TipoAcessorios", "Valor", "ViolinoId" },
                values: new object[] { 1, "Produzido na Alemanha, utilizando os melhores materiais, a marca Pirastro é dominante no segmento de...", "Pirastro", "Resina Natural de Pinho", "CV-52", "Breu", 2, 52.649999999999999, 1 });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 85, 254, 216, 190, 195, 155, 148, 189, 112, 203, 146, 158, 198, 176, 223, 174, 6, 66, 56, 64, 173, 106, 240, 126, 196, 150, 124, 106, 132, 206, 147, 227, 13, 123, 134, 20, 105, 191, 212, 54, 71, 134, 233, 192, 185, 142, 150, 1, 69, 246, 188, 254, 186, 79, 230, 211, 56, 229, 178, 117, 240, 187, 114, 71 }, new byte[] { 38, 121, 119, 185, 173, 252, 57, 210, 31, 193, 91, 90, 231, 172, 76, 4, 203, 201, 224, 94, 169, 168, 233, 35, 225, 94, 246, 179, 35, 93, 121, 128, 81, 134, 102, 157, 219, 22, 169, 254, 191, 53, 132, 194, 143, 138, 42, 76, 250, 249, 237, 38, 131, 18, 122, 194, 150, 170, 217, 69, 184, 164, 74, 101, 174, 113, 6, 176, 6, 90, 163, 215, 205, 249, 73, 102, 197, 101, 134, 230, 134, 251, 49, 30, 135, 60, 16, 163, 28, 68, 45, 43, 82, 248, 215, 134, 28, 104, 91, 226, 10, 209, 123, 166, 125, 93, 74, 80, 235, 195, 92, 69, 249, 26, 100, 74, 152, 207, 107, 242, 244, 130, 192, 57, 88, 215, 193, 183 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.UpdateData(
                table: "TB_VIOLINOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "Materiais", "UsuarioId", "Valor" },
                values: new object[] { "Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)", "Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba", 1, 1283.8499999999999 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_VIOLINOS_UsuarioId",
                table: "TB_VIOLINOS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACESSORIOS_ViolinoId",
                table: "TB_ACESSORIOS",
                column: "ViolinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_VIOLINOS_TB_USUARIOS_UsuarioId",
                table: "TB_VIOLINOS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_VIOLINOS_TB_USUARIOS_UsuarioId",
                table: "TB_VIOLINOS");

            migrationBuilder.DropTable(
                name: "TB_ACESSORIOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_VIOLINOS_UsuarioId",
                table: "TB_VIOLINOS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_VIOLINOS");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "TB_VIOLINOS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "AcessoriosViolino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acessorios = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Materiais = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ViolinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoriosViolino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcessoriosViolino_TB_VIOLINOS_ViolinoId",
                        column: x => x.ViolinoId,
                        principalTable: "TB_VIOLINOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_VIOLINOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "Materiais", "Valor" },
                values: new object[] { "Queixeira, estandarte, cravelhas e botão: Ébano Encordoamento: M Calixto Arco de crina natural e madeira maçaranduba Estojo Gota  Ajuste Profissional (cavalete original, alma, pestana, cravelhas", "Violino: Abeto e Atiro.  Ébano Arco:Maçaranduba", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoriosViolino_ViolinoId",
                table: "AcessoriosViolino",
                column: "ViolinoId",
                unique: true);
        }
    }
}
