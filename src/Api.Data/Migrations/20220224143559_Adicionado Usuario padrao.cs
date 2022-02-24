using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionadoUsuariopadrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("367373e9-6929-42e7-b01e-9dfde32ed40c"), new DateTime(2022, 2, 24, 14, 35, 58, 746, DateTimeKind.Utc).AddTicks(1007), "admin@email.com", "administrador", new DateTime(2022, 2, 24, 14, 35, 58, 746, DateTimeKind.Utc).AddTicks(2013) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("367373e9-6929-42e7-b01e-9dfde32ed40c"));
        }
    }
}
