using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelacoesUsuarioViolinoAcessorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "Marca", "Materiais", "Modelo", "Nome", "TipoAcessorios", "Valor" },
                values: new object[] { "As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes...", "Mauro Calixto", "Núcleo de fibra sintética e Revestimento em aço", "Padrão", "Encordeamento", 1, 52.0 });

            migrationBuilder.InsertData(
                table: "TB_ACESSORIOS",
                columns: new[] { "Id", "Descricao", "Marca", "Materiais", "Modelo", "Nome", "TipoAcessorios", "Valor", "ViolinoId" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 193, 187, 208, 29, 238, 224, 65, 75, 163, 3, 92, 123, 135, 68, 135, 51, 43, 74, 63, 144, 18, 195, 46, 29, 227, 253, 168, 8, 110, 254, 161, 122, 120, 89, 254, 177, 75, 189, 142, 169, 95, 33, 112, 150, 189, 126, 14, 24, 80, 124, 143, 248, 251, 175, 13, 175, 35, 60, 51, 196, 230, 75, 98, 184 }, new byte[] { 50, 52, 138, 114, 170, 218, 19, 90, 230, 153, 67, 214, 98, 29, 87, 230, 211, 26, 118, 74, 63, 78, 24, 77, 96, 95, 87, 223, 206, 38, 22, 116, 50, 33, 109, 59, 0, 203, 236, 4, 245, 167, 81, 112, 174, 241, 12, 103, 105, 133, 6, 171, 152, 182, 249, 77, 57, 225, 224, 67, 90, 159, 212, 155, 151, 114, 73, 68, 185, 207, 89, 234, 158, 93, 0, 100, 27, 146, 250, 128, 70, 158, 223, 36, 205, 138, 55, 45, 70, 125, 242, 75, 175, 53, 103, 49, 87, 148, 45, 115, 118, 25, 23, 193, 254, 201, 93, 162, 75, 51, 67, 66, 178, 20, 186, 6, 119, 226, 134, 13, 234, 180, 204, 210, 99, 246, 203, 92 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "TB_ACESSORIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descricao", "Marca", "Materiais", "Modelo", "Nome", "TipoAcessorios", "Valor" },
                values: new object[] { "Produzido na Alemanha, utilizando os melhores materiais, a marca Pirastro é dominante no segmento de...", "Pirastro", "Resina Natural de Pinho", "CV-52", "Breu", 2, 52.649999999999999 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 45, 167, 20, 65, 110, 161, 233, 105, 45, 203, 229, 201, 162, 89, 223, 122, 179, 180, 99, 6, 61, 147, 8, 237, 101, 174, 127, 71, 210, 246, 19, 16, 79, 128, 171, 140, 37, 14, 20, 36, 168, 29, 45, 183, 236, 148, 91, 3, 188, 114, 7, 197, 111, 173, 91, 114, 234, 85, 22, 193, 39, 97, 89, 235 }, new byte[] { 78, 81, 129, 144, 122, 105, 90, 220, 152, 241, 32, 15, 22, 9, 138, 190, 68, 226, 119, 240, 146, 224, 129, 34, 59, 144, 134, 8, 194, 191, 112, 173, 98, 56, 63, 170, 27, 232, 234, 39, 22, 127, 89, 17, 58, 141, 114, 226, 222, 124, 162, 4, 248, 223, 197, 70, 132, 143, 212, 51, 222, 170, 153, 249, 75, 235, 148, 208, 93, 239, 57, 176, 97, 178, 87, 242, 255, 185, 139, 213, 41, 162, 203, 241, 139, 231, 58, 234, 160, 208, 86, 175, 177, 226, 240, 122, 139, 157, 3, 236, 189, 144, 149, 224, 46, 218, 75, 153, 75, 108, 0, 8, 243, 237, 69, 228, 12, 109, 105, 127, 24, 210, 227, 212, 252, 210, 91, 247 } });
        }
    }
}
