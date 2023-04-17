
namespace CoursesTikects.DAL.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Ticket> tickets { get; set; } = new HashSet<Ticket>();
    }
}
