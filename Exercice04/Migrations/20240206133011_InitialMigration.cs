using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatarURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "email", "firstname", "lastname", "password", "phone" },
                values: new object[] { 1, "URL1", new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testc@mail.com", "Iori", "Yagami", "pwd1", "0123456789" });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "email", "firstname", "lastname", "password", "phone" },
                values: new object[] { 2, "URL2", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testc@mail.com", "Kyo", "Kusanagi", "pwd2", "0123456789" });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "email", "firstname", "lastname", "password", "phone" },
                values: new object[] { 3, "URL3", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testc@mail.com", "Kazuya", "Mishima", "pwd3", "0123456789" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");
        }
    }
}
