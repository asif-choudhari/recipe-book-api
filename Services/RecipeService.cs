using System.Text.Json;
using AutoMapper;
using recipe_book_api.DTOs;
using recipe_book_api.Models;
using recipe_book_api.Repsitories.Interfaces;
using recipe_book_api.Services.Interfaces;

namespace recipe_book_api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IIdentityRepository identityRepository;
        private readonly IMapper mapper;

        private readonly string dbName = "recipe";

        public RecipeService(IMapper mapper, IRecipeRepository recipeRepository, IIdentityRepository identityRepository)
        {
            this.mapper = mapper;
            this.recipeRepository = recipeRepository;
            this.identityRepository = identityRepository;   
        }

        public async Task<List<RecipeDTO>> GetRecipesList()
        {
            List<Recipe> recipes = await recipeRepository.GetRecipesList();

            foreach (Recipe recipe in recipes)
            {
                recipe.Ingredients = JsonSerializer.Deserialize<Ingredient[]>(recipe.IngredientsJSON);
            }

            List<RecipeDTO> recipesList = mapper.Map<List<RecipeDTO>>(recipes);
            return recipesList;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            int id = await identityRepository.GetId(dbName);
            recipe.Id = id;

            int newId = id + 1;
            await identityRepository.UpdateId(dbName, newId);

            recipe.IngredientsJSON = JsonSerializer.Serialize(recipe.Ingredients);
            await recipeRepository.AddRecipe(recipe);
        }

        public async Task<bool> UpdateRecipe(int id, Recipe newRecipe)
        {
            newRecipe.IngredientsJSON = JsonSerializer.Serialize(newRecipe.Ingredients);
            return await recipeRepository.UpdateRecipe(id, newRecipe);
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            return await recipeRepository.DeleteRecipe(id);
        }
    }
}
