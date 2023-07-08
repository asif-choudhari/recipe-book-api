using AutoMapper;
using recipe_book_api.DTOs;
using recipe_book_api.Models;

namespace recipe_book_api.Mappings
{
    public class ApiMappingProfiles : Profile
    {
        public ApiMappingProfiles()
        {
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<Recipe, RecipeDTO>();
        }
    }
}
