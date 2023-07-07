using recipe_book_api.DTOs;
using recipe_book_api.Models;

namespace recipe_book_api.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<List<IngredientDTO>> GetIngredientsList();
        Task<IngredientDTO> GetIngredientById(int id);
        Task AddIngredient(Ingredient ingredient);
        Task AddIngredients(Ingredient[] ingredients);
        Task<bool> UpdateIngredient(int id, Ingredient newIngredient);
        Task<bool> DeleteIngredient(int id);
    }
}
