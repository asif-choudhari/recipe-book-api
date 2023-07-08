using Microsoft.EntityFrameworkCore;
using recipe_book_api.Context;
using recipe_book_api.Models;
using recipe_book_api.Repsitories.Interfaces;

namespace recipe_book_api.Repsitories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext recipeDbContext;

        public RecipeRepository(RecipeDbContext recipeDbContext)
        {
            this.recipeDbContext = recipeDbContext;
        }

        public async Task<List<Recipe>> GetRecipesList()
        {
            List<Recipe> recipeList = await recipeDbContext.Recipes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return recipeList;
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            Recipe recipe = await recipeDbContext.Recipes.Where(i => i.Id == id).FirstOrDefaultAsync<Recipe>();
            return recipe;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await recipeDbContext.Recipes.AddAsync(recipe);
            await recipeDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateRecipe(int id, Recipe newRecipe)
        {
            Recipe recipe = await GetRecipeById(id);

            if (recipe == null)
            {
                return false;
            }

            recipe.Name = newRecipe.Name;
            recipe.Description = newRecipe.Description;
            recipe.ImagePath = newRecipe.ImagePath;
            recipe.IngredientsJSON = newRecipe.IngredientsJSON;
            recipe.Ingredients = newRecipe.Ingredients;
            await recipeDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            Recipe recipe = await GetRecipeById(id);

            if (recipe == null)
            {
                return false;
            }

            recipeDbContext.Recipes.Remove(recipe);
            await recipeDbContext.SaveChangesAsync();
            return true;
        }
    }
}
