using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.BL.Dtos
{
    public class TicketWithDevsNumberDto
    {
        public int Id { get; set; }
        public string Desciption { get; set; } = string.Empty;
        public int DevelopersCount { get; set; }
    }
}
