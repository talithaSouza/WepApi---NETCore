using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class trocadevalortabelaCEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d84ec852-ede6-4984-ac5e-538d27611314"));

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Cep",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 60);

            migrationBuilder.InsertData(
                table: "Municipio",
                columns: new[] { "Id", "CodIBGE", "CreateAt", "Nome", "UfID", "UpdateAt" },
                values: new object[] { new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f"), 1295438038, null, "Sobral", new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), null });

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreateAt",
                value: new DateTime(2022, 4, 11, 12, 27, 19, 412, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("5197581a-4b7b-4c2c-b04c-cb7bf7fba391"), new DateTime(2022, 4, 11, 12, 27, 19, 410, DateTimeKind.Utc).AddTicks(62), "admin@email.com", "administrador", new DateTime(2022, 4, 11, 12, 27, 19, 410, DateTimeKind.Utc).AddTicks(1199) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("ea78590c-5276-4e6d-8840-83d984c3b40f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5197581a-4b7b-4c2c-b04c-cb7bf7fba391"));

            migrationBuilder.AlterColumn<int>(
                name: "Logradouro",
                table: "Cep",
                type: "int",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3763));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 28, 12, 42, 57, 754, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("d84ec852-ede6-4984-ac5e-538d27611314"), new DateTime(2022, 3, 28, 12, 42, 57, 751, DateTimeKind.Utc).AddTicks(9796), "admin@email.com", "administrador", new DateTime(2022, 3, 28, 12, 42, 57, 752, DateTimeKind.Utc).AddTicks(855) });
        }
    }
}
