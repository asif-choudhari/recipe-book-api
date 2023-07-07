using Microsoft.EntityFrameworkCore;
using recipe_book_api.Context;
using recipe_book_api.Models;
using recipe_book_api.Repsitories.Interfaces;

namespace recipe_book_api.Repsitories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly RecipeDbContext recipeDbContext;

        public IdentityRepository(RecipeDbContext recipeDbContext)
        {
            this.recipeDbContext = recipeDbContext;
        }

        public async Task<int> GetId(string dbName)
        {
            Identity identity = await recipeDbContext.Identities.AsNoTracking().Where(i => i.IdentityName.Equals(dbName)).FirstOrDefaultAsync();
            int identityId = identity.IdentityId;

            return identityId;
        }

        public async Task UpdateId(string dbName, int newId)
        {
            Identity identity = await recipeDbContext.Identities.AsNoTracking().Where(i => i.IdentityName.Equals(dbName)).FirstOrDefaultAsync();
            
            recipeDbContext.Identities.Remove(identity);
            await recipeDbContext.SaveChangesAsync();

            identity.IdentityId = newId;
            await recipeDbContext.AddAsync(identity);

            await recipeDbContext.SaveChangesAsync();
        }
    }
}
