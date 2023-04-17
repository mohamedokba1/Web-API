using CoursesTikects.BL.Dtos;
using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;

namespace CoursesTikects.BL.Managers
{
    public class DepartmentsManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentsManager(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task Add(Department entity)
        {
            await _repo.Add(entity);
        }

        public async Task<Department> GetByID(int id)
        {
            return await _repo.GetById(id);
        }

        public void Delete(Department entity)
        {
            _repo.Delete(entity);
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task SaveChanges()
        {
            await _repo.SaveCahnges();
        }

        public void Update(Department entity)
        {
            _repo.Update(entity);
        }
        public DepartmentWithTicketDetails? GetDepartmentDetails(int id)
        {
            var Depts = _repo.GetDepartmentsDetails();
            return Depts.Select(d => new DepartmentWithTicketDetails()
            {
                Id = id,
                Name = d.Name,
                Tickets = d.tickets.Select(T => new TicketWithDevsNumberDto() { Id = T.Id, Desciption = T.description, DevelopersCount = T.Developers.Count() })
            }).FirstOrDefault(D => D.Id == id);
        }
    }
}
