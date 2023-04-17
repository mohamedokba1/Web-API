using CoursesTikects.DAL.Data.Models;

namespace CoursesTikects.DAL.Repos.Inertfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public IEnumerable<Department> GetDepartmentsDetails();
    }
}
