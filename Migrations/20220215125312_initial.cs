using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRecu.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prendas",
                columns: table => new
                {
                    PrendaId = table.Column<int>(type: "int", nullable: false),
                    Prenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prendas", x => x.PrendaId);
                });

            migrationBuilder.CreateTable(
                name: "TiketDeCompra",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiketDeCompra", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    PrendaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrendasPrendaId = table.Column<int>(type: "int", nullable: true),
                    TiketDeCompraTicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Prendas_PrendasPrendaId",
                        column: x => x.PrendasPrendaId,
                        principalTable: "Prendas",
                        principalColumn: "PrendaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_TiketDeCompra_TiketDeCompraTicketId",
                        column: x => x.TiketDeCompraTicketId,
                        principalTable: "TiketDeCompra",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PrendasPrendaId",
                table: "Pedido",
                column: "PrendasPrendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_TiketDeCompraTicketId",
                table: "Pedido",
                column: "TiketDeCompraTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Prendas");

            migrationBuilder.DropTable(
                name: "TiketDeCompra");
        }
    }
}
