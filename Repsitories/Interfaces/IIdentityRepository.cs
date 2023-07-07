namespace recipe_book_api.Repsitories.Interfaces
{
    public interface IIdentityRepository
    {
        Task<int> GetId(string dbName);
        Task UpdateId(string dbName, int newId);
    }
}
