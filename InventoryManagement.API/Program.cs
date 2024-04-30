
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

            #region independance injection
            builder.Services.AddScoped<IUnitOfWork<InventoryDbContext>, UnitOfWork<InventoryDbContext>>();
            builder.Services.AddScoped<IItemServices, ItemServices>();
            builder.Services.AddScoped<ISupplierServices, SupplierServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<ILocationServices, LocationServices>();
            //builder.Services.AddScoped<ITransportationServices,TransportationServices>();
            //builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IBaseRepository<Item>, BaseRepository<Item>>();
            builder.Services.AddScoped<IBaseRepository<Supplier>, BaseRepository<Supplier>>();
            builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            builder.Services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
            builder.Services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.Services.AddScoped<IBaseRepository<Location>, BaseRepository<Location>>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ILocationRepository,LocationRepository>();
            #endregion
            //Signal R
            //builder.Services.AddSignalR();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHub<InventoryHub>("/InventoryHub");
            //    // Map other endpoints...
            //});


            app.MapControllers();

            app.Run();
        }
    }
}