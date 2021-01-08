using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dividas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(nullable: false),
                    NomeDevedor = table.Column<string>(nullable: true),
                    CPFDevedor = table.Column<string>(nullable: true),
                    Juros = table.Column<decimal>(nullable: false),
                    Multa = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DividaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Dividas_DividaId",
                        column: x => x.DividaId,
                        principalTable: "Dividas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dividas",
                columns: new[] { "Id", "CPFDevedor", "Juros", "Multa", "NomeDevedor", "Numero" },
                values: new object[] { 1, "123456", 1m, 2m, "José", 1010 });

            migrationBuilder.InsertData(
                table: "Dividas",
                columns: new[] { "Id", "CPFDevedor", "Juros", "Multa", "NomeDevedor", "Numero" },
                values: new object[] { 2, "123777", 2m, 4m, "João", 1011 });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 1, new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 100m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 2, new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 100m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 3, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 200m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 4, new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 200m });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_DividaId",
                table: "Parcelas",
                column: "DividaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Dividas");
        }
    }
}
