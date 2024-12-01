using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TB_VIOLINOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Materiais = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VIOLINOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_VIOLINOS_TB_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 70, 65, 222, 201, 180, 48, 91, 244, 49, 235, 141, 83, 185, 100, 31, 34, 55, 88, 84, 105, 8, 136, 250, 72, 10, 151, 3, 27, 189, 152, 43, 230, 242, 95, 231, 207, 178, 162, 21, 80, 20, 2, 83, 121, 119, 158, 15, 217, 239, 250, 5, 136, 57, 224, 54, 206, 246, 90, 216, 84, 107, 1, 55, 199 }, new byte[] { 32, 62, 64, 103, 147, 235, 241, 186, 26, 231, 237, 92, 247, 248, 111, 182, 139, 220, 167, 170, 165, 91, 16, 38, 91, 67, 75, 74, 237, 128, 104, 230, 179, 217, 2, 244, 85, 81, 180, 173, 97, 19, 105, 197, 4, 50, 41, 113, 33, 146, 117, 40, 196, 215, 228, 201, 37, 75, 74, 53, 208, 34, 57, 194, 71, 181, 78, 229, 178, 18, 168, 1, 129, 172, 68, 87, 234, 89, 180, 154, 132, 176, 24, 38, 98, 227, 161, 100, 131, 247, 153, 139, 213, 234, 36, 187, 138, 164, 103, 69, 24, 189, 44, 120, 205, 38, 94, 8, 126, 59, 75, 9, 113, 235, 192, 76, 236, 78, 133, 106, 130, 27, 47, 172, 129, 149, 89, 251 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.InsertData(
                table: "TB_VIOLINOS",
                columns: new[] { "Id", "Descricao", "Marca", "Materiais", "Modelo", "UsuarioId", "Valor" },
                values: new object[] { 1, "Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)", "Eagles", "Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba", "CV-12", 1, 1283.8499999999999 });

            migrationBuilder.InsertData(
                table: "TB_ACESSORIOS",
                columns: new[] { "Id", "Descricao", "Marca", "Materiais", "Modelo", "Nome", "TipoAcessorios", "Valor", "ViolinoId" },
                values: new object[,]
                {
                    { 1, "As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes...", "Mauro Calixto", "Núcleo de fibra sintética e Revestimento em aço", "Padrão", "Encordeamento", 1, 52.0, 1 },
                    { 2, "Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de...", "Pirastro", "Resina Natural de Pinho", "CV-52", "Breu", 2, 54.649999999999999, 1 },
                    { 3, "A espaleira Lunnon new apresenta design mais anatômico, que proporciona conforto, segurança e flexibilidade...", "Lunnon", "Plástico injetável", "New", "Espaleira", 3, 36.0, 1 },
                    { 4, "Produto Original da Fábrica, é necessário fazer furos e ajustes em um Luthier para que seja regulado em seu instrumento...", " NETO VIOLINOS", "ÉBANO MESCLADO", "KIT 04 CRAVELHAS TAMARINDO PREMIUM", "Cravelha", 4, 48.950000000000003, 1 },
                    { 5, "Também pode ser chamado simplesmente de fixo, é uma peça que utilizamos para ajudar no momento de afinação...", "Mavis", "Metal", "Niquelado", "Microafinador", 5, 9.3599999999999994, 1 },
                    { 6, "A queixeira é um acessório que se encaixa no extremo do corpo do violino ou da viola de arco. É um peça essencial...", "Mavis", "Madeira de Ébano", "Ébano", "Queixeira", 6, 84.200000000000003, 1 },
                    { 7, "Disponíveis nos tamanhos:  1/10, 1/16, 1/4, 1/2, 3/4 e 4/4...", "Mavis", "Madeira de Ébano", "Ébano", "Estandarte", 7, 50.939999999999998, 1 },
                    { 8, "Cavalete fabricado com madeira Maple de ótima qualidade, com a finalidade de proporcionar ao músico uma maior precisão...", "Mavis", "Madeira Mapple", "Madeira Mapple Mavis", "Cavalete", 8, 12.470000000000001, 1 },
                    { 9, "Descubra a qualidade excepcional do Arco Para Violino Eagle 4/4 VWB-44R Crina Animal Natural...", "Eagle", "Hardwood no formato Octogonal (oitavado), Crina animal natural, Talão de ébano com madre-pérola Olho París incrustada", "VWB44R", "Arco", 9, 89.099999999999994, 1 },
                    { 10, "Disponíveis nos tamanhos: 1/16, 1/8, 1/4, 1/2 e 3/4...", "Mavis", "Madeira de Ébano", "Ébano", "Espelho", 10, 90.439999999999998, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACESSORIOS_ViolinoId",
                table: "TB_ACESSORIOS",
                column: "ViolinoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VIOLINOS_UsuarioId",
                table: "TB_VIOLINOS",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ACESSORIOS");

            migrationBuilder.DropTable(
                name: "TB_VIOLINOS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}
