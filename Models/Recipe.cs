namespace recipe_book_api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string? IngredientsJSON { get; set; }
        public Ingredient[] Ingredients { get; set; }
    }
}
