using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.VerdeVolt.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaMatriz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatrizEnergeticaVerdeVolt",
                columns: table => new
                {
                    MatrizId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PorcentagemFonteRenovavel = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Hidroeletrica = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    GasNatural = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Biomassa = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Petroleo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Eolica = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Solar = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nuclear = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrizEnergeticaVerdeVolt", x => x.MatrizId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatrizEnergeticaVerdeVolt");
        }
    }
}
