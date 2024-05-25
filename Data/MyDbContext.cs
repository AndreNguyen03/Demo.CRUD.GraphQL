using Demo.CRUD.GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.CRUD.GraphQL.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Cake> Cake {  get; set; }

    }
}
