
using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using InventoryManagement.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            //builder.Services.AddSwaggerGen();
            #region AddSwaggerGen
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Pappa´s API", Version = "v1" });

                // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
            });
            #endregion

            #region Add Contecction String
            var connectionString = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(connectionString));
            #endregion

            #region AddAuthentication
            builder.Services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(options => {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                     ValidateAudience = true,
                     ValidAudience = builder.Configuration["JWT:ValidAudiance"],
                     IssuerSigningKey =
                     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                 };
             });
            #endregion
            
            #region independance injection
            builder.Services.AddScoped<IUnitOfWork<InventoryDbContext>, UnitOfWork<InventoryDbContext>>();
            builder.Services.AddScoped<IItemServices, ItemServices>();
            builder.Services.AddScoped<ISupplierServices, SupplierServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<ILocationServices, LocationServices>();
            builder.Services.AddScoped<ITransportationServices,TransportationServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IBaseRepository<Item>, BaseRepository<Item>>();
            builder.Services.AddScoped<IBaseRepository<Supplier>, BaseRepository<Supplier>>();
            builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            builder.Services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
            builder.Services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.Services.AddScoped<IBaseRepository<Location>, BaseRepository<Location>>();
            builder.Services.AddScoped<IBaseRepository<Transportation>, BaseRepository<Transportation>>();
            builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ILocationRepository,LocationRepository>();
            builder.Services.AddScoped<ITransportationRepository, TransportationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            #endregion


            #region Signal R
            //builder.Services.AddSignalR();
            #endregion
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

            /*app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHub<InventoryHub>("/InventoryHub");
            //    endpoints.MapControllers();
            //});*/



        }
    }
}