using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedingCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dividas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 22, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Dividas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 22, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 23, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 23, DateTimeKind.Utc).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 23, DateTimeKind.Utc).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2021, 3, 12, 12, 38, 51, 23, DateTimeKind.Utc).AddTicks(6606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dividas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dividas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
