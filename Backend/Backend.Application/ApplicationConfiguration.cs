using Backend.Application.Profiles;
using Backend.Application.Services.Auth.Concretes;
using Backend.Application.Services.Auth.Interfaces;
using Backend.Application.Services.Discounts.Abstracts;
using Backend.Application.Services.Discounts.Concretes;
using Backend.Application.Services.Discounts.Interfaces;
using Backend.Application.Services.Products.Concretes;
using Backend.Application.Services.Products.Interfaces;
using Backend.Infrastructure.Repositories.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using DotNetEnv;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Application
{
    public static class ApplicationConfiguration
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(UserProfile).Assembly)
            );
            string authority = Env.GetString("AUTH_JWT_AUTHORITY");
            string audience = Env.GetString("AUTH_JWT_AUDIENCE");

            FirebaseApp.Create(
                options: new AppOptions
                {
                    Credential = GoogleCredential.FromJson(Env.GetString("FIREBASE_CREDENTIALS"))
                }
            );




            services.AddAuthentication()
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.Authority = authority;
                    options.Audience = audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authority,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateLifetime = true
                    };
                }
            );



            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IComboRepository, ComboRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDiscountService, DiscountService>(
                provider => new DiscountService(
                    [
                        new StockAgeDiscount(new Dictionary<int, double>
                            {
                                { 3, 30.0 },
                                { 2, 20.0 },
                                { 1, 5.0 }
                            }
                            ),
                        new BrandDiscount(
                            new Dictionary<string, double>
                            {
                                { "Pepsi", 10.0 },
                                { "Jack Daniels", 9.0 },
                                { "Corona", 12.0 },
                                { "Hennessy", 8.0 }

                            }
                        )
                    ]
                )
            );

            services.AddSingleton<IJwtDecoder, JwtDecoder>();
        }
    }
}
