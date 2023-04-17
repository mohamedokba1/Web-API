using CoursesTikects.DAL.Data.Context;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;
using Microsoft.EntityFrameworkCore;

namespace CoursesTikects.DAL.Repos
{
    public class TicketsRepo : ITicketRepository
    {
        private readonly TicketsContext _context;

        public TicketsRepo(TicketsContext context)
        {
            _context = context;
        }

        public async Task Add(Ticket entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public IEnumerable<Ticket> GetTicketDetails()
        {
            return _context.Tickets.Include(t => t.Developers).ToList();
        }

        public async Task SaveCahnges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
        }
    }
}
