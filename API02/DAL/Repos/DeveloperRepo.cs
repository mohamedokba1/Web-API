using CoursesTikects.DAL.Data.Context;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesTikects.DAL.Repos
{
    public class DeveloperRepo : IDeveloperRepository
    {
        private readonly TicketsContext _context;

        public DeveloperRepo(TicketsContext context)
        {
            _context = context;
        }

        public async Task Add(Developer entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(Developer entity)
        {
            _context.Developers.Remove(entity);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task<Developer> GetById(int id)
        {
            return await _context.Developers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Developer>> GetRange(IEnumerable<int> Ids)
        {
            return await _context.Developers.Where(T => Ids.Contains(T.Id)).ToListAsync();
        }

        public async Task SaveCahnges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Developer entity)
        {
            _context.Developers.Update(entity);
        }
    }
}
