using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CVproject.Migrations
{
    /// <inheritdoc />
    public partial class exempeldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cvs",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CvId", "Email", "EmailConfirmed", "IsPrivate", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3153b77c-24cc-4be2-887e-f4cf5ee0a517", 0, "65e71733-5f77-438a-b998-36bdaf6314a9", 3, "peter.pan@gmail.com", false, false, false, null, "Peter Pan", null, null, null, null, false, null, "bbd51003-5fbf-418c-ba15-e11d9a61fe58", false, "Neverland" },
                    { "aa970336-7717-434c-8db0-42b53bd65679", 0, "8b87e382-bf0f-4ad7-9c39-b002b575f994", 2, "homer.simpson@gmail.com", false, false, false, null, "Homer Simpson", null, null, null, null, false, null, "829981e9-bd49-445e-856e-ac2a66242388", false, "Springfield" },
                    { "ba3b9682-3d2a-4f1d-8db3-a1d575b35cf1", 0, "74580290-5e3d-46b1-b6bd-f0bac0455c12", 4, "mojo.jojo@gmail.com", false, false, false, null, "Mojo Jojo", null, null, null, null, false, null, "1eabb308-47e7-4d14-8392-842d8780ea34", false, "KingMojo" },
                    { "f46844d6-310f-4400-9264-d62f7487a0ce", 0, "b06d9a2c-2292-4e37-ad08-a7670582a918", 1, "peter.griffin@gmail.com", false, true, false, null, "Peter Griffin", null, null, null, null, false, null, "f14a0dfb-f93f-4632-98dc-d075f9d6c23c", false, "Griff007" }
                });

            migrationBuilder.InsertData(
                table: "Competences",
                columns: new[] { "Id", "CvId", "Name" },
                values: new object[,]
                {
                    { 1, 1, ".NET" },
                    { 2, 2, "Behaviour science" },
                    { 3, 3, "Leadership" },
                    { 4, 4, "Ambitious" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CvId", "EndYear", "Orientation", "StartYear", "University" },
                values: new object[,]
                {
                    { 1, 1, 2014, "Software Engineering", 2011, "Örebro" },
                    { 2, 2, 2015, "Behaviour science", 2014, "Mälardalens högskola" },
                    { 3, 2, 2020, "Nuclear safety", 2015, "Mälardalens högskola" },
                    { 4, 3, 2020, "Finding Neverland", 2014, "Mälardalens högskola" },
                    { 5, 4, 2006, "Lab science", 2000, "Townville" },
                    { 6, 4, 2008, "Lab assistent", 2007, "Townville" }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CvId", "Employer", "EndYear", "StartYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, "PN", 2021, 2015, "Customs Administrator" },
                    { 2, 1, "Happy-Go-Lucky", 2022, 2021, "Senior developer" },
                    { 3, 2, "Power Plant", 2022, 2016, "Inspector" },
                    { 4, 3, "Öppenvård", 2022, 2020, "Kurator" },
                    { 5, 4, "Professor Utonium", 2022, 2009, "Lab assistent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Competences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cvs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Heading",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PersonId",
                table: "Messages",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_PersonId",
                table: "Messages",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
