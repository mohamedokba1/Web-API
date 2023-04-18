using API03.Data;
using API03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Database
            builder.Services.AddDbContext<APIDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
            #endregion

            #region Identity Service
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

            }).AddEntityFrameworkStores<DbContext>();
            #endregion

            #region Authentication 
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JWT";
                options.DefaultChallengeScheme = "JWT";

            }).AddJwtBearer("JWT", options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration.GetValue<string>("Authentication:SecurityKey") ?? ""))
                };
            });

            #endregion

            #region Autherization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("UserOrAdmin", policy =>
                    policy.RequireRole("Admin", "User"));
            });

            #endregion
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}