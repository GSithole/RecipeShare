using RecipeShare.Models;

namespace RecipeShare.Repository
{
    public interface IRecipeRepository
    {
        public Task<Recipe> GetRecipeAsync(int id);
        public Task<IEnumerable<Recipe>> GetRecipesAsync(string? dietaryTag = null);
        public Task<bool> DeleteRecipeAsync(int id);
        public Task<bool> UpdateRecipeAsync(Recipe recipe);
        public Task<bool> CreateRecipeAsync(Recipe recipe);
    }
}
