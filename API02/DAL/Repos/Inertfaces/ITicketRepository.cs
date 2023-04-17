using CoursesTikects.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.DAL.Repos.Inertfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        public IEnumerable<Ticket> GetTicketDetails();
    }
}
