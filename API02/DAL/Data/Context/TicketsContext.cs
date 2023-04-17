using CoursesTikects.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CoursesTikects.DAL.Data.Context
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions<TicketsContext> options):base(options ) { }
        
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Developer> Developers => Set<Developer>();

        //Seeding (Populate tables with initial data when they are created)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tickets
            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket { Id = 1, description="dec1", Title="title1", Dept_Id = 3},
                new Ticket { Id = 2, description="dec2", Title="title2", Dept_Id = 1},
                new Ticket { Id = 3, description="dec3", Title="title3", Dept_Id = 1},
                new Ticket { Id = 4, description="dec4", Title="title4", Dept_Id = 2},
                new Ticket { Id = 5, description="dec5", Title="title5", Dept_Id = 3}
            };
            #endregion

            #region Departments
            List<Department> departments = new List<Department>()
            {
                new Department{Id= 1, Name = "Web Development"},
                new Department{Id= 2, Name = "Open Source"},
                new Department{Id= 3, Name = "AI"},
            };
            #endregion

            #region Developers
            List<Developer> developers = new List<Developer>()
            {
                new Developer{Id=1, Name= "Mohamed Okba"},
                new Developer{Id=2, Name= "Ahmed Khaled"},
                new Developer{Id=3, Name= "Ayman Hussien"},
                new Developer{Id=4, Name= "Ebrahim Fathy"},
                new Developer{Id=5, Name= "Kareem Ahmed"}
            };
            #endregion

            modelBuilder.Entity<Ticket>().HasData(tickets);
            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Developer>().HasData(developers);
        }
    }
}
