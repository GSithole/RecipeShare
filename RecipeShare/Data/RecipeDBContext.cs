using Microsoft.EntityFrameworkCore;
using RecipeShare.Models;

namespace RecipeShare.Data
{
    public class RecipeDBContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    RecipeId = 1,
                    Title = "Classic Spaghetti Carbonara",
                    Ingredients = "Spaghetti, Guanciale (or Pancetta), Eggs, Pecorino Romano, Black Pepper",
                    Steps = "1. Cook spaghetti. 2. Fry guanciale. 3. Whisk eggs, cheese, pepper. 4. Combine with pasta and guanciale.",
                    CookingTimeMinutes = 20,
                    DietaryTags = "Non-Vegetarian"
                },
                new Recipe
                {
                    RecipeId = 2,
                    Title = "Vegan Lentil Soup",
                    Ingredients = "Red lentils, Carrots, Celery, Onion, Garlic, Vegetable broth, Diced tomatoes, Spices",
                    Steps = "1. Sauté aromatics. 2. Add lentils, vegetables, broth, tomatoes. 3. Simmer until lentils are tender.",
                    CookingTimeMinutes = 45,
                    DietaryTags = "Vegan,Vegetarian,Gluten-Free"
                },
                new Recipe
                {
                    RecipeId = 3,
                    Title = "Quick Chicken Stir-Fry",
                    Ingredients = "Chicken breast, Broccoli, Bell peppers, Soy sauce, Ginger, Garlic, Rice vinegar, Sesame oil",
                    Steps = "1. Marinate chicken. 2. Stir-fry chicken. 3. Add vegetables and sauce. 4. Serve with rice.",
                    CookingTimeMinutes = 25,
                    DietaryTags = "Non-Vegetarian,Gluten-Free (with Tamari)"
                }
            );
        }
    }
}
