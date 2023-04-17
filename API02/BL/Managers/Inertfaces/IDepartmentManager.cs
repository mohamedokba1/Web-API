using CoursesTikects.BL.Dtos;
using CoursesTikects.DAL.Data.Models;
using System;
namespace CoursesTikects.BL.Managers.Inertfaces
{
    public interface IDepartmentManager : IManager<Department>
    {
        public DepartmentWithTicketDetails? GetDepartmentDetails(int id);
    }
}
