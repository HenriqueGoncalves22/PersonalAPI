using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VIOLINOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcessoriosViolino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Marca = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Materiais = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acessorios = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "TB_VIOLINOS",
                columns: new[] { "Id", "Descricao", "Marca", "Materiais", "Modelo", "Valor" },
                values: new object[] { 1, "Queixeira, estandarte, cravelhas e botão: Ébano Encordoamento: M Calixto Arco de crina natural e madeira maçaranduba Estojo Gota  Ajuste Profissional (cavalete original, alma, pestana, cravelhas", "Eagles", "Violino: Abeto e Atiro.  Ébano Arco:Maçaranduba", "CV-12", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoriosViolino_ViolinoId",
                table: "AcessoriosViolino",
                column: "ViolinoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoriosViolino");

            migrationBuilder.DropTable(
                name: "TB_VIOLINOS");
        }
    }
}
