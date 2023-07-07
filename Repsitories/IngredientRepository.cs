using Microsoft.EntityFrameworkCore;
using recipe_book_api.Context;
using recipe_book_api.Models;
using recipe_book_api.Repsitories.Interfaces;

namespace recipe_book_api.Repsitories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeDbContext recipeDbContext;

        public IngredientRepository(RecipeDbContext recipeDbContext)
        {
            this.recipeDbContext = recipeDbContext;
        }

        public async Task<List<Ingredient>> GetIngredientsList()
        {
            List<Ingredient> ingredientList = await recipeDbContext.Ingredients.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return ingredientList;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            Ingredient ingredient = await recipeDbContext.Ingredients.Where(i => i.Id == id).FirstOrDefaultAsync<Ingredient>();
            return ingredient;
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await recipeDbContext.Ingredients.AddAsync(ingredient);
            await recipeDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateIngredient(int id, Ingredient newIngredient)
        {
            Ingredient ingredient = await GetIngredientById(id);

            if (ingredient == null)
            {
                return false;
            }

            ingredient.Name = newIngredient.Name;
            ingredient.Amount = newIngredient.Amount;
            await recipeDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIngredient(int id)
        {
            Ingredient ingredient = await GetIngredientById(id);

            if(ingredient == null)
            {
                return false;
            }

            recipeDbContext.Remove(ingredient);
            await recipeDbContext.SaveChangesAsync();
            return true;
        }
    }
}
