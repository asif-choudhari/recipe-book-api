using AutoMapper;
using recipe_book_api.DTOs;
using recipe_book_api.Models;
using recipe_book_api.Repsitories.Interfaces;
using recipe_book_api.Services.Interfaces;

namespace recipe_book_api.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;
        private readonly IIdentityRepository identityRepository;
        private readonly IMapper mapper;

        private readonly string dbName = "ingredient";

        public IngredientService(IMapper mapper, IIngredientRepository ingredientRepository, IIdentityRepository identityRepository)
        {
            this.mapper = mapper;
            this.ingredientRepository = ingredientRepository;
            this.identityRepository = identityRepository;
        }

        public async Task<List<IngredientDTO>> GetIngredientsList()
        {
            var ingredients = await ingredientRepository.GetIngredientsList();
            List<IngredientDTO> ingredientsList = mapper.Map<List<IngredientDTO>>(ingredients);
            return ingredientsList;
        }

        public async Task<IngredientDTO> GetIngredientById(int id)
        {
            var ingredient = await ingredientRepository.GetIngredientById(id);
            IngredientDTO ingredientDTO = mapper.Map<IngredientDTO>(ingredient);
            return ingredientDTO;
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            int id = await identityRepository.GetId(dbName);
            ingredient.Id = id;
            await ingredientRepository.AddIngredient(ingredient);

            int newId = id + 1;
            await identityRepository.UpdateId(dbName, newId);
        }

        public async Task AddIngredients(Ingredient[] ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                int id = await identityRepository.GetId(dbName);
                ingredient.Id = id;
                await ingredientRepository.AddIngredient(ingredient);

                int newId = id + 1;
                await identityRepository.UpdateId(dbName, newId);
            }
        }

        public async Task<bool> UpdateIngredient(int id, Ingredient newIngredient)
        {
            return await ingredientRepository.UpdateIngredient(id, newIngredient);
        }

        public async Task<bool> DeleteIngredient(int id)
        {
            return await ingredientRepository.DeleteIngredient(id);
        }
    }
}
