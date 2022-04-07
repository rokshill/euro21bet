using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TournamentForm.Application.Common.Interfaces;
using TournamentForm.Application.Common.Interfaces.Identity;
using TournamentForm.Application.Common.Security;
using TournamentForm.Infrastructure.Identity;
using TournamentForm.Infrastructure.Persistence;
using TournamentForm.Infrastructure.Services;

namespace TournamentForm.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TournamentForm"));
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
                options.Authority = "https://rokshill-dev.eu.auth0.com/";
                options.Audience = "https://default.rokshill.dev/api";
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