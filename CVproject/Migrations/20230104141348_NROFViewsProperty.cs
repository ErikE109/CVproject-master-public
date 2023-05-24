using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CVproject.Migrations
{
    /// <inheritdoc />
    public partial class NROFViewsProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3153b77c-24cc-4be2-887e-f4cf5ee0a517");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa970336-7717-434c-8db0-42b53bd65679");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aaaaaaaa-bbbb-cccc-dddddddddddd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba3b9682-3d2a-4f1d-8db3-a1d575b35cf1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f46844d6-310f-4400-9264-d62f7487a0ce");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfViews",
                table: "Cvs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CvId", "Email", "EmailConfirmed", "IsPrivate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0809527e-b3b9-4387-8953-a86f79de13cc", 0, "6afa4981-035e-4137-bb07-20f76250580b", 3, "peter.pan@gmail.com", false, false, false, null, "Peter Pan", null, null, null, null, false, null, "de642445-3bd2-494e-bd28-cd27c50c3530", false, "Neverland" },
                    { "14ad059c-f280-446d-bbd2-a4196d35e1c6", 0, "a0d3fd3a-96f0-4949-be5b-67d3ca682b7f", 1, "peter.griffin@gmail.com", false, true, false, null, "Peter Griffin", null, null, null, null, false, null, "ec7d4230-7dba-4aa2-bf02-f23bb26f427d", false, "Griff007" },
                    { "18d491ef-a1b0-4d96-9555-65aaadad5946", 0, "b146d1b4-8949-4dfa-9882-66aa4ce18d04", 2, "homer.simpson@gmail.com", false, false, false, null, "Homer Simpson", null, null, null, null, false, null, "70b2fff7-5a84-42c7-b8fe-f9a4a54afb29", false, "Springfield" },
                    { "6ce8b41c-6722-49d6-ad1b-91d04479cb96", 0, "9e68b546-7576-40ca-b969-fd3ea54f1b6f", 4, "mojo.jojo@gmail.com", false, false, false, null, "Mojo Jojo", null, null, null, null, false, null, "1d5bfff3-cb94-4935-bbd4-d49c04539efc", false, "KingMojo" }
                });

            migrationBuilder.UpdateData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberOfViews",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberOfViews",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberOfViews",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberOfViews",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0809527e-b3b9-4387-8953-a86f79de13cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14ad059c-f280-446d-bbd2-a4196d35e1c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18d491ef-a1b0-4d96-9555-65aaadad5946");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ce8b41c-6722-49d6-ad1b-91d04479cb96");

            migrationBuilder.DropColumn(
                name: "NumberOfViews",
                table: "Cvs");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CvId", "Email", "EmailConfirmed", "IsPrivate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3153b77c-24cc-4be2-887e-f4cf5ee0a517", 0, "65e71733-5f77-438a-b998-36bdaf6314a9", 3, "peter.pan@gmail.com", false, false, false, null, "Peter Pan", null, null, null, null, false, null, "bbd51003-5fbf-418c-ba15-e11d9a61fe58", false, "Neverland" },
                    { "aa970336-7717-434c-8db0-42b53bd65679", 0, "8b87e382-bf0f-4ad7-9c39-b002b575f994", 2, "homer.simpson@gmail.com", false, false, false, null, "Homer Simpson", null, null, null, null, false, null, "829981e9-bd49-445e-856e-ac2a66242388", false, "Springfield" },
                    { "aaaaaaaa-bbbb-cccc-dddddddddddd", 0, "3d5112d8-bff8-49d8-91e7-7d520ac2f2f3", 1, "annamaria@gmail.com", false, false, false, null, "Anna-Maria Olsson", null, null, null, null, false, null, "3479c486-0b3b-4372-ab19-716a2fe0d838", false, "Impala87" },
                    { "ba3b9682-3d2a-4f1d-8db3-a1d575b35cf1", 0, "74580290-5e3d-46b1-b6bd-f0bac0455c12", 4, "mojo.jojo@gmail.com", false, false, false, null, "Mojo Jojo", null, null, null, null, false, null, "1eabb308-47e7-4d14-8392-842d8780ea34", false, "KingMojo" },
                    { "f46844d6-310f-4400-9264-d62f7487a0ce", 0, "b06d9a2c-2292-4e37-ad08-a7670582a918", 1, "peter.griffin@gmail.com", false, true, false, null, "Peter Griffin", null, null, null, null, false, null, "f14a0dfb-f93f-4632-98dc-d075f9d6c23c", false, "Griff007" }
                });
        }
    }
}
