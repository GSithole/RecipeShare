using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RecipeShare.Controllers;
using RecipeShare.Models;
using RecipeShare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Tests.Controller
{
    public class RecipesControllerTests
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly RecipesController _controller;

        public RecipesControllerTests()
        {
            _recipeRepository = A.Fake<IRecipeRepository>();
            _controller = new RecipesController(_recipeRepository);
        }

        #region get tests

        [Fact]
        public async Task RecipesController_GetRecipes_ReturnNotFound()
        {
            #region Arrange
            IEnumerable<Recipe> recipes = new Recipe[0];
            A.CallTo(() => _recipeRepository.GetRecipesAsync(null)).Returns(recipes);
            #endregion Arrange

            #region Act

            var results = await _controller.GetRecipes();
            #endregion Act

            #region Assert
            results.Should().BeOfType(typeof(NotFoundResult));
            #endregion Assert
        }

        [Fact]
        public async Task RecipesController_GetRecipe_ReturnOk()
        {
            #region Arrange
            int recipeId = 1;
            Recipe recipe = new Recipe()
            {
                RecipeId = recipeId,
                Title = "Test",
                CookingTimeMinutes = 60,
                Ingredients = "test Ingredients",
                Steps ="test steps",
                DietaryTags = "test tags"
            };

            A.CallTo(() => _recipeRepository.GetRecipeAsync(recipeId)).Returns(recipe);
            #endregion Arrange

            #region Act

            var results = await _controller.GetRecipe(recipeId);
            #endregion Act

            #region Assert
            results.Should().BeOfType(typeof(OkObjectResult));
            #endregion Assert
        }

        [Fact]
        public async Task RecipesController_GetRecipe_ReturnNotFound()
        {
            #region Arrange
            int recipeId = 1;
            Recipe recipe = null;

            A.CallTo(() => _recipeRepository.GetRecipeAsync(recipeId)).Returns(recipe);
            #endregion Arrange

            #region Act
            var results = await _controller.GetRecipe(recipeId);
            #endregion Act

            #region Assert
            results.Should().BeOfType(typeof(NotFoundResult));
            #endregion Assert
        }

        #endregion get tests

        #region Create tests

        [Fact]
        public async Task RecipesController_CreateRecipe_ReturnOK()
        {
            #region Arrange
            var recipe = A.Fake<Recipe>();

            A.CallTo(() =>  _recipeRepository.CreateRecipeAsync(recipe)).Returns(true);
            #endregion Arrange

            #region Act

            var results = await _controller.CreateRecipe(recipe);
            #endregion Act

            #region Assert
            results.Should().BeOfType(typeof(OkResult));
            #endregion Assert
        }
        [Fact]
        public async Task RecipesController_CreateRecipe_ReturnBadRequest()
        {
            #region Arrange
            Recipe recipe = null;            
            #endregion Arrange

            #region Act

            var results = await _controller.CreateRecipe(recipe);
            #endregion Act

            #region Assert
            results.Should().BeOfType<BadRequestResult>();
            #endregion Assert
        }
        #endregion Create tests

        #region Update tests

        [Fact]
        public async Task RecipesController_UpdateRecipe_ReturnOK()
        {
            #region Arrange
            var recipe = A.Fake<Recipe>();

            A.CallTo(() => _recipeRepository.UpdateRecipeAsync(recipe)).Returns(true);
            #endregion Arrange

            #region Act

            var results = await _controller.UpdateRecipe(recipe);
            #endregion Act

            #region Assert
            results.Should().BeOfType(typeof(OkResult));
            #endregion Assert
        }
        [Fact]
        public async Task RecipesController_UpdateRecipe_ReturnBadRequestIfRecipeIsNull()
        {
            #region Arrange
            Recipe recipe = null;
            A.CallTo(() => _recipeRepository.UpdateRecipeAsync(recipe)).Returns(false);
            #endregion Arrange

            #region Act
            var results = await _controller.UpdateRecipe(recipe);
            #endregion Act

            #region Assert
            results.Should().BeOfType<BadRequestResult>();
            #endregion Assert
        }

        [Fact]
        public async Task RecipesController_UpdateRecipe_ReturnBadRequestIfNoMatch()
        {
            #region Arrange
            Recipe recipe = A.Fake<Recipe>();
            A.CallTo(() => _recipeRepository.UpdateRecipeAsync(recipe)).Returns(false);
            #endregion Arrange

            #region Act

            var results = await _controller.UpdateRecipe(recipe);

            #endregion Act

            #region Assert
            results.Should().BeOfType<BadRequestResult>();
            #endregion Assert
        }

        #endregion Update tests

        #region Delete tests

        [Fact]
        public async Task RecipesController_DeleteRecipe_ReturnOk()
        {
            #region Arrange
            int recipeId = 99;
            A.CallTo(() => _recipeRepository.DeleteRecipeAsync(recipeId)).Returns(true);
            #endregion Arrange

            #region Act

            var results = await _controller.DeleteRecipe(recipeId);

            #endregion Act

            #region Assert
            results.Should().BeOfType<OkResult>();
            #endregion Assert
        }

        [Fact]
        public async Task RecipesController_DeleteRecipe_ReturnNotFound()
        {
            #region Arrange
            int recipeId = 99;
            A.CallTo(() => _recipeRepository.DeleteRecipeAsync(recipeId)).Returns(false);
            #endregion Arrange

            #region Act

            var results = await _controller.DeleteRecipe(recipeId);

            #endregion Act

            #region Assert
            results.Should().BeOfType<NotFoundResult>();
            #endregion Assert
        }

        #endregion Delete tests

    }
}
