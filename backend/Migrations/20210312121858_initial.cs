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
                    Removed = table.Column<bool>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
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
                    Removed = table.Column<bool>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
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
                columns: new[] { "Id", "CPFDevedor", "CreateAt", "Juros", "Multa", "NomeDevedor", "Numero", "Removed", "UpdateAt" },
                values: new object[] { 1, "123456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 2m, "José", 1010, false, null });

            migrationBuilder.InsertData(
                table: "Dividas",
                columns: new[] { "Id", "CPFDevedor", "CreateAt", "Juros", "Multa", "NomeDevedor", "Numero", "Removed", "UpdateAt" },
                values: new object[] { 2, "123777", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 4m, "João", 1011, false, null });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "CreateAt", "DataVencimento", "DividaId", "Numero", "Removed", "UpdateAt", "Valor" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, false, null, 100m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "CreateAt", "DataVencimento", "DividaId", "Numero", "Removed", "UpdateAt", "Valor" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, false, null, 100m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "CreateAt", "DataVencimento", "DividaId", "Numero", "Removed", "UpdateAt", "Valor" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, false, null, 200m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "CreateAt", "DataVencimento", "DividaId", "Numero", "Removed", "UpdateAt", "Valor" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, false, null, 200m });

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
