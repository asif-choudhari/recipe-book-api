using recipe_book_api.Models;

namespace recipe_book_api.Repsitories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetIngredientsList();
        Task<Ingredient> GetIngredientById(int id);
        Task AddIngredient(Ingredient ingredient);
        Task<bool> UpdateIngredient(int id, Ingredient newIngredient);
        Task<bool> DeleteIngredient(int id);
    }
}
