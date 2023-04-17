using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.BL.Dtos
{
    public class TicketDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Dept_Id { get; set; }
        public IEnumerable<int> DevelopersIds { get; set; } = Enumerable.Empty<int>();
    }
}
