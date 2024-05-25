using Demo.CRUD.GraphQL.Data;
using Demo.CRUD.GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.CRUD.GraphQL.GraphQL_Types
{
    public class Query
    {
        public async Task<List<Cake>> AllCakeAsync([Service] MyDbContext context)
        {
            return await context.Cake.ToListAsync();
        }

        public async Task<Cake> CakeByIdAsync([Service] MyDbContext context, int id)
        {
            return await context.Cake.FindAsync(id);
        }
    }
}
