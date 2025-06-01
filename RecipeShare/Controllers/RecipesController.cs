using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Models;
using RecipeShare.Repository;

namespace RecipeShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipesAsync();

            if (!recipes.Any())
            {
                return NotFound();
            }
            return Ok(recipes);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetRecipes([FromQuery] string dietaryTag)
        //{
        //    var recipes = await _recipeRepository.GetRecipesAsync(dietaryTag);

        //    if (!recipes.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(recipes);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {

            var recipe = await _recipeRepository.GetRecipeAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            if (recipe == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _recipeRepository.CreateRecipeAsync(recipe);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecipe(Recipe recipe)
        {
            var results = await _recipeRepository.UpdateRecipeAsync(recipe);
            if (results)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var Results = await _recipeRepository.DeleteRecipeAsync(id);

            if (Results)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
