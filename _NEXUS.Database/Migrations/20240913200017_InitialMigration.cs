using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _NEXUS.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_NX_PEDIDOS",
                columns: table => new
                {
                    ID_PEDIDO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NR_PEDIDO = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    VL_QUANTIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VL_PEDIDO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NX_PEDIDOS", x => x.ID_PEDIDO);
                });

            migrationBuilder.CreateTable(
                name: "TB_NX_PRODUTOS",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_PRODUTO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TP_PRODUTO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NM_MARCA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    NM_MODELO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    VL_QUANTIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VL_PRODUTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_PRODUTO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NX_PRODUTOS", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_NX_USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NR_CPF = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NR_TELEFONE = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NX_USUARIOS", x => x.ID_USUARIO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_NX_PEDIDOS");

            migrationBuilder.DropTable(
                name: "TB_NX_PRODUTOS");

            migrationBuilder.DropTable(
                name: "TB_NX_USUARIOS");
        }
    }
}
