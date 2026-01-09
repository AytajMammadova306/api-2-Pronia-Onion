using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Infrastructure.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService,TokenService>();
            services.AddAuthentication(opt =>
            {   
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                opt=>opt.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateIssuerSigningKey=true,
                    ValidateLifetime=true,



                    ValidIssuer = configuration["JWT:issuer"],
                    ValidAudience = configuration["JWT:audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:secretKey"])),
                    LifetimeValidator = (_, exp, token, param) => token==null&&exp==null ? exp>DateTime.UtcNow: false
                }
                );
            return services;
        }
    }
}
