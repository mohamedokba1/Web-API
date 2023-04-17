using CoursesTikects.BL.Managers;
using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.DAL.Data.Context;
using CoursesTikects.DAL.Repos;
using CoursesTikects.DAL.Repos.Inertfaces;
using Microsoft.EntityFrameworkCore;

namespace API02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Database
            builder.Services.AddDbContext<TicketsContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CourseTikerts"));
            });
            #endregion

            #region Builder Services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Repository Services
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepo>();
            builder.Services.AddScoped<IDeveloperRepository, DeveloperRepo>();
            builder.Services.AddScoped<ITicketRepository, TicketsRepo>();
            #endregion

            #region Managers Services
            builder.Services.AddScoped<ITicketManager, TicketsManager>();
            builder.Services.AddScoped<IDeveloperManager, DevelopersManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentsManager>();
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