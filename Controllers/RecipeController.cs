using Microsoft.AspNetCore.Mvc;
using recipe_book_api.Models;
using recipe_book_api.Services;
using recipe_book_api.Services.Interfaces;

namespace recipe_book_api.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        [Route("getRecipesList")]
        public async Task<IActionResult> GetRecipesList()
        {
            var recipesList = await recipeService.GetRecipesList();
            return Ok(recipesList);
        }

        [HttpGet]
        [Route("getRecipeById")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpPost]
        [Route("addRecipe")]
        public async Task<IActionResult> AddRecipe(Recipe recipe)
        {
            await recipeService.AddRecipe(recipe);

            return Ok(recipe);
        }

        [HttpPut]
        [Route("updateRecipe")]
        public async Task<IActionResult> UpdateRecipe(int id, Recipe newRecipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(newRecipe);
            }
            var updateStatus = await recipeService.UpdateRecipe(id, newRecipe);

            if (updateStatus)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("deleteRecipe")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var deleteStatus = await recipeService.DeleteRecipe(id);

            if (deleteStatus)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
