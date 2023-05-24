using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CVproject.Migrations
{
    /// <inheritdoc />
    public partial class propetiesToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Experiences",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Employer",
                table: "Experiences",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Educations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Orientation",
                table: "Educations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Competences",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CvId", "Email", "EmailConfirmed", "Github", "IsActive", "IsPrivate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "23762386-6101-45c8-a353-d8570e65cc0d", 0, "8e11617d-765b-4a30-9bd0-ad15a1954263", 4, "mojo.jojo@gmail.com", false, null, true, false, false, null, "Mojo Jojo", null, null, null, null, false, null, "7644ac7c-df2a-4c69-8fa6-eca07262a638", false, "KingMojo" },
                    { "425e4751-ae94-4e7a-96e2-a12820e6217f", 0, "bebc41a5-c40e-4a93-b705-0b38db167509", 3, "peter.pan@gmail.com", false, null, true, false, false, null, "Peter Pan", null, null, null, null, false, null, "9750552f-3020-4f49-9367-eb859565a7ab", false, "Neverland" },
                    { "92d88db4-6f58-4641-b22d-840876b15f7b", 0, "69f46909-2c0a-4c0f-8c27-04f731230043", 1, "peter.griffin@gmail.com", false, null, true, true, false, null, "Peter Griffin", null, null, null, null, false, null, "8a647271-78b9-437c-9024-7032b035f63f", false, "Griff007" },
                    { "9de3078f-8682-4ec8-897b-a92040a9ad01", 0, "2bd24aac-b431-4880-ac04-db7963ac82ce", 2, "homer.simpson@gmail.com", false, null, true, false, false, null, "Homer Simpson", null, null, null, null, false, null, "6b7b5e21-c4e4-4b85-a342-9a5e29f29342", false, "Springfield" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23762386-6101-45c8-a353-d8570e65cc0d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "425e4751-ae94-4e7a-96e2-a12820e6217f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92d88db4-6f58-4641-b22d-840876b15f7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de3078f-8682-4ec8-897b-a92040a9ad01");

            migrationBuilder.DropColumn(
                name: "Github",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Employer",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "University",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Orientation",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Competences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CvId", "Email", "EmailConfirmed", "IsPrivate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0809527e-b3b9-4387-8953-a86f79de13cc", 0, "6afa4981-035e-4137-bb07-20f76250580b", 3, "peter.pan@gmail.com", false, false, false, null, "Peter Pan", null, null, null, null, false, "dino.jpg", "de642445-3bd2-494e-bd28-cd27c50c3530", false, "Neverland" },
                    { "14ad059c-f280-446d-bbd2-a4196d35e1c6", 0, "a0d3fd3a-96f0-4949-be5b-67d3ca682b7f", 1, "peter.griffin@gmail.com", false, true, false, null, "Peter Griffin", null, null, null, null, false, "pic.jpg", "ec7d4230-7dba-4aa2-bf02-f23bb26f427d", false, "Griff007" },
                    { "18d491ef-a1b0-4d96-9555-65aaadad5946", 0, "b146d1b4-8949-4dfa-9882-66aa4ce18d04", 2, "homer.simpson@gmail.com", false, false, false, null, "Homer Simpson", null, null, null, null, false, "koala.jpg", "70b2fff7-5a84-42c7-b8fe-f9a4a54afb29", false, "Springfield" },
                    { "6ce8b41c-6722-49d6-ad1b-91d04479cb96", 0, "9e68b546-7576-40ca-b969-fd3ea54f1b6f", 4, "mojo.jojo@gmail.com", false, false, false, null, "Mojo Jojo", null, null, null, null, false, "pic2.jpg", "1d5bfff3-cb94-4935-bbd4-d49c04539efc", false, "KingMojo" }
                });
        }
    }
}
