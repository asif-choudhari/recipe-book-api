using recipe_book_api.Models;

namespace recipe_book_api.Repsitories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipesList();
        Task<Recipe> GetRecipeById(int id);
        Task AddRecipe(Recipe recipe);
        Task<bool> UpdateRecipe(int id, Recipe newRecipe);
        Task<bool> DeleteRecipe(int id);
    }
}
