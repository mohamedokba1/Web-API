using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.BL.Dtos
{
    public class DepartmentWithTicketDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TicketWithDevsNumberDto> Tickets { get; set; } = Enumerable.Empty<TicketWithDevsNumberDto>();
    }
}
