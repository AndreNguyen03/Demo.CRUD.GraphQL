using Demo.CRUD.GraphQL.Data;
using Demo.CRUD.GraphQL.Data.Entities;

namespace Demo.CRUD.GraphQL.GraphQL_Types
{
    public class Mutation
    {
        public async Task<Cake> SaveCakeAsync([Service] MyDbContext context, Cake newCake)
        {
            context.Cake.Add(newCake);
            await context.SaveChangesAsync();
            return newCake;
        }

        public async Task<Cake> UpdateCakeAsync([Service] MyDbContext context, Cake updateCake)
        {
            context.Cake.Update(updateCake);
            await context.SaveChangesAsync();
            return updateCake;
        }

        public async Task<string> DeleteCakeAsync([Service] MyDbContext context, int id)
        {
            var cakeToDelete = await context.Cake.FindAsync(id);
            if (cakeToDelete == null)
            {
                return "invalid operation";
            }
            context.Cake.Remove(cakeToDelete);
            await context.SaveChangesAsync();
            return "Delete successful!";
        }
    }
}
