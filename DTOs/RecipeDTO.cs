using recipe_book_api.Models;

namespace recipe_book_api.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Ingredient[] Ingredients { get; set; }

    }
}
