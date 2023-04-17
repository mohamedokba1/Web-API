using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesTikects.DAL.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
}
