
using Demo.CRUD.GraphQL.Data;
using Demo.CRUD.GraphQL.GraphQL_Types;
using Microsoft.EntityFrameworkCore;

namespace Demo.CRUD.GraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection"));
            });

            builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();


            var app = builder.Build();
        
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}
