using CoursesTikects.DAL.Data.Context;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesTikects.DAL.Repos
{
    public class DepartmentRepo : IDepartmentRepository
    {
        private readonly TicketsContext _context;

        public DepartmentRepo(TicketsContext context)
        {
            _context = context;
        }
        public async Task Add(Department entity)
        {
            await _context.Departments.AddAsync(entity);
        }

        public void Delete(Department entity)
        {
            _context.Departments.Remove(entity);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public IEnumerable<Department> GetDepartmentsDetails()
        {
            return _context.Departments.Include(d => d.tickets).ToList();
        }

        public async Task SaveCahnges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Department entity)
        {
            _context.Departments.Update(entity);
        }
    }
}
