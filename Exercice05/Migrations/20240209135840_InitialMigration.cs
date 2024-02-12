using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice05.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pizza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pizza_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_ingredient_pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizza",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "id", "description", "name", "PizzaId" },
                values: new object[,]
                {
                    { 1, "Tomate d'Espagne", "Tomate", null },
                    { 2, "Poulet grillé", "Poulet", null },
                    { 3, "Viande de boeuf", "Viande", null }
                });

            migrationBuilder.InsertData(
                table: "pizza",
                columns: new[] { "id", "description", "image_url", "name", "price", "pizza_type" },
                values: new object[,]
                {
                    { 1, "Classic pizza with tomato sauce, mozzarella, and fresh basil.", "https://example.com/images/margherita.jpg", "Margherita", 8.99m, 0 },
                    { 2, "Spicy pepperoni with mozzarella cheese and tomato sauce.", "https://example.com/images/pepperoni.jpg", "Pepperoni", 10.99m, 0 },
                    { 3, "A delightful mix of seasonal vegetables, mozzarella, and tomato sauce.", "https://example.com/images/vegetarian.jpg", "Vegetarian", 9.99m, 0 },
                    { 4, "Ham and pineapple with mozzarella cheese and tomato sauce.", "https://example.com/images/hawaiian.jpg", "Hawaiian", 11.99m, 1 },
                    { 5, "Hot jalapenos, spicy pepperoni, mozzarella, and tomato sauce.", "https://example.com/images/spicy.jpg", "Spicy", 12.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "firstname", "is_admin", "lastname", "password" },
                values: new object[] { 1, "root@utopios.com", "Root", true, "ROOT", "UEFzczAwKytEZXMgcGFpbGxldHRlcyBkYW5zIG1lcyB5ZXV4IEtldmlu" });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_PizzaId",
                table: "ingredient",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "pizza");
        }
    }
}
