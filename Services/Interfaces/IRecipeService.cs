using Microsoft.AspNetCore.Mvc;
using recipe_book_api.DTOs;
using recipe_book_api.Models;

namespace recipe_book_api.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeDTO>> GetRecipesList();
        Task<RecipeDTO> GetRecipeById(int id);
        Task AddRecipe(Recipe recipe);
        Task<bool> UpdateRecipe(int id, Recipe newRecipe);
        Task<bool> DeleteRecipe(int id);
    }
}
