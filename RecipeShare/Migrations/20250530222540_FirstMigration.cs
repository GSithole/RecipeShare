using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeShare.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    DietaryTags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CookingTimeMinutes", "DietaryTags", "Ingredients", "Steps", "Title" },
                values: new object[,]
                {
                    { 1, 20, "Non-Vegetarian", "Spaghetti, Guanciale (or Pancetta), Eggs, Pecorino Romano, Black Pepper", "1. Cook spaghetti. 2. Fry guanciale. 3. Whisk eggs, cheese, pepper. 4. Combine with pasta and guanciale.", "Classic Spaghetti Carbonara" },
                    { 2, 45, "Vegan,Vegetarian,Gluten-Free", "Red lentils, Carrots, Celery, Onion, Garlic, Vegetable broth, Diced tomatoes, Spices", "1. Sauté aromatics. 2. Add lentils, vegetables, broth, tomatoes. 3. Simmer until lentils are tender.", "Vegan Lentil Soup" },
                    { 3, 25, "Non-Vegetarian,Gluten-Free (with Tamari)", "Chicken breast, Broccoli, Bell peppers, Soy sauce, Ginger, Garlic, Rice vinegar, Sesame oil", "1. Marinate chicken. 2. Stir-fry chicken. 3. Add vegetables and sauce. 4. Serve with rice.", "Quick Chicken Stir-Fry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
