
using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using InventoryManagement.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API
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
            // Add Contecction String
            var connectionString = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(connectionString));
           
            //independance injection
            builder.Services.AddScoped<IUnitOfWork<InventoryDbContext>, UnitOfWork<InventoryDbContext>>();
            builder.Services.AddScoped<IItemServices, ItemServices>();
            builder.Services.AddScoped<ISupplierServices, SupplierServices>();
            builder.Services.AddScoped<IBaseRepository<Item>, BaseRepository<Item>>();
            builder.Services.AddScoped<IBaseRepository<Supplier>, BaseRepository<Supplier>>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            //Signal R
            builder.Services.AddSignalR();
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

            app.Run();
        }
    }
}