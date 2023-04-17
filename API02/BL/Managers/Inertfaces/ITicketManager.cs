using CoursesTikects.DAL.Data.Models;
using System;
namespace CoursesTikects.BL.Managers.Inertfaces
{
    public interface ITicketManager : IManager<Ticket>
    {
        public IEnumerable<TicketReadOnlyDto> GetTicketDetails();
    }
}
