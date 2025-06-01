using Microsoft.EntityFrameworkCore;
using RecipeShare.Data;
using RecipeShare.Models;

namespace RecipeShare.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDBContext _dbContext;
        public RecipeRepository(RecipeDBContext dBContext) 
        {
            _dbContext = dBContext;
        }
        public async Task<bool> CreateRecipeAsync(Recipe recipe)
        {
            if (recipe == null)
            {
                return false;
            }
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipe = await _dbContext.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await _dbContext.Recipes.FindAsync(id);
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string? dietaryTag = null)
        {
            var results =  await _dbContext.Recipes.ToListAsync();
            if (!string.IsNullOrEmpty(dietaryTag))
            {
                return (IEnumerable<Recipe>)results.Where(x => x.DietaryTags.ToLower().Contains(dietaryTag.ToLower()));
            }

            return (IEnumerable<Recipe>)results;
        }

        public async Task<bool> UpdateRecipeAsync(Recipe recipe)
        {
            if(recipe == null)
                return false;

            var recipeObj = await _dbContext.Recipes.FindAsync(recipe.RecipeId);
            if (recipeObj != null)
            {
                recipeObj.Title = recipe.Title;
                recipeObj.Ingredients = recipe.Ingredients;
                recipeObj.CookingTimeMinutes = recipe.CookingTimeMinutes;
                recipeObj.Steps = recipe.Steps;
                recipeObj.DietaryTags = recipe.DietaryTags;
                await _dbContext.SaveChangesAsync();
                return true;                
            }
            return false;
        }
    }
}
