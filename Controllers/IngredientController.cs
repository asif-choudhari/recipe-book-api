using Microsoft.AspNetCore.Mvc;
using recipe_book_api.Models;
using recipe_book_api.Services.Interfaces;

namespace recipe_book_api.Controllers
{
    [ApiController]
    [Route("api/ingredient")]
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("getIngredientsList")]
        public async Task<IActionResult> GetIngredientsList()
        {
            var ingredientsList = await ingredientService.GetIngredientsList();
            return Ok(ingredientsList);
        }

        [HttpGet]
        [Route("getIngredientById")]
        public async Task<IActionResult> GetIngredientById(int id)
        {
            var ingredient = await ingredientService.GetIngredientById(id);
            return Ok(ingredient);
        }

        [HttpPost]
        [Route("addIngredient")]
        public async Task<IActionResult> AddIngredient(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ingredientService.AddIngredient(ingredient);

            return Ok(ingredient);
        }

        [HttpPost]
        [Route("addIngredients")]
        public async Task<IActionResult> AddIngredients(Ingredient[] ingredients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await ingredientService.AddIngredients(ingredients);

            return Ok(ingredients);
        }

        [HttpPut]
        [Route("updateIngredient")]
        public async Task<IActionResult> UpdateIngredient(int id, Ingredient newIngredient)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(newIngredient);
            }
            var updateStatus = await ingredientService.UpdateIngredient(id, newIngredient);

            if (updateStatus)
            {
                return Ok();
            }
            
            return NotFound();
        }

        [HttpDelete]
        [Route("deleteIngredient")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var deleteStatus = await ingredientService.DeleteIngredient(id);

            if (deleteStatus)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
