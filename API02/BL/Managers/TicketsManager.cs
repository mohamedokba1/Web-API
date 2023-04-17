using CoursesTikects.BL.Dtos;
using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;
using System.Linq;

namespace CoursesTikects.BL.Managers
{
    public class TicketsManager : ITicketManager
    {
        private readonly ITicketRepository _repo;

        public TicketsManager(ITicketRepository repo)
        {
            _repo = repo;
        }
        public async Task Add(Ticket entity)
        {
            await _repo.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _repo.Delete(entity);
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Ticket> GetByID(int id)
        {
            return await _repo.GetById(id); 
        }

        public IEnumerable<TicketReadOnlyDto> GetTicketDetails()
        {
            IEnumerable<Ticket> ticket = _repo.GetTicketDetails();
            return ticket.Select(T => new TicketReadOnlyDto()
            {
                Id = T.Id,
                Description = T.description,
                Department = new DepartmentReadDto() { Id = T.Department.Id, Name = T.Department.Name },
                Title = T.Title,
                Developers = T.Developers.Select(D => new DeveloperReadDto() { Id = D.Id, Name = D.Name })
            }).ToList();
        }

        public async Task SaveChanges()
        {
            await _repo.SaveCahnges();
        }

        public void Update(Ticket entity)
        {
            _repo.Update(entity);
        }
    }
}
