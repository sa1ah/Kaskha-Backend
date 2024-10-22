
using Kashkha.BL;
using Kashkha.BL.Managers.CartManager;
using Kashkha.BL.Mapping;
using Kashkha.DAL;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Kashkha.DAL.Repositories.UsersRepository;
using Kashkha.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Kashkha.BL.Managers.UsersManager;
using Kashkha.BL.Helpers;
using Stripe;

namespace Kashkha.API
{
	public class Program
	{
		public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IUsersManager, UsersManager>();
            services.AddAutoMapper(typeof(MappingProfile));

  
}
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers().ConfigureApiBehaviorOptions(op=>
			op.SuppressModelStateInvalidFilter=true);
			builder.Services.AddDbContext<KashkhaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KashkhaDb")));

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddScoped<IUsersManager, UsersManager>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IProductManager, ProductManager>();

            builder.Services.AddScoped<IFavoriteManager, FavoriteManager>();
            builder.Services.AddScoped<IFavoriteRepository, FavoritRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ICartManager, CartManager>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
			builder.Services.AddScoped<IShopManager, ShopManager>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(option =>
			{
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
				return ConnectionMultiplexer.Connect(connection);
			});

			builder.Services.AddScoped<IReviewManager, ReviewManager>();
			builder.Services.AddScoped<IOrderManager, OrderManager>();

			builder.Services.AddAutoMapper(typeof(MappingProfile));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
            //identity
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;

            })
         .AddEntityFrameworkStores<KashkhaContext>();
            //configure authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//api reply when dta is unauthen
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    var keyfrmconfig = builder.Configuration.GetValue<string>("SecretKey");

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyfrmconfig!));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        //ValidIssuer = "",
                        ValidateAudience = false,
                        //ValidAudience = "",
                        IssuerSigningKey = key
                    };
                });
            builder.Services.AddAuthorization(options =>
            {

                options.AddPolicy("AdminOnly", policy =>
            policy.RequireRole("Admin"));

                options.AddPolicy("UserOnly", policy =>
                    policy.RequireRole("User"));
                options.AddPolicy("ShopOwnersOnly", policy =>
                   policy.RequireRole("Shop Owner"));
            });

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    policy => policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });
            var app = builder.Build();
            using (var s = app.Services.CreateScope())
            {
                var userManager = s.ServiceProvider.GetRequiredService<UserManager<User>>();
                 await UserSeeding.SeedUser(userManager);
                  
            }

            ////var s = app.Services.GetRequiredService<UserManager<User>>();
            //// UserSeeding.SeedUser(s);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Shop Owner", "Customer" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

       
            app.UseHttpsRedirection();
            app.UseCors("AllowLocalhost4200");
            app.UseStaticFiles();
            app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
