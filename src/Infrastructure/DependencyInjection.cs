using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Application.Common.Interfaces.Identity;
using Euro21bet.Application.Common.Security;
using Euro21bet.Infrastructure.Identity;
using Euro21bet.Infrastructure.Persistence;
using Euro21bet.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Euro21bet.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("Euro21betDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                            .EnableRetryOnFailure()));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IDateTime, DateTimeService>();

            // 1. Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://muchoborwroclaw.eu.auth0.com/";
                options.Audience = "https://euro21bet.muchoborwroclaw.pl/api";
                options.SaveToken = true;
            });
            
            // Allowing CORS for all domains and methods for the purpose of sample
            services.AddCors(o => o.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.Configure<ClaimsTypesSettings>(options => configuration.GetSection("Authorization:ClaimsTypes").Bind(options));
            services.AddScoped<IUserService, UserService>();
            //services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            //services.AddTransient<ICurrentIdentityUserProvider, UserIdentity>();

            services.AddScoped<UserIdentity>();
            services.AddScoped<ICurrentIdentitySetter>(x => x.GetRequiredService<UserIdentity>());
            services.AddScoped<ICurrentIdentityUserProvider>(x => x.GetRequiredService<UserIdentity>());
            services.AddScoped<ICurrentIdentityPermissionsProvider>(x => x.GetRequiredService<UserIdentity>());
        }
    }
}