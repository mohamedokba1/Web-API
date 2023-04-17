using CoursesTikects.BL.Dtos;

namespace CoursesTikects.BL
{
    public class TicketReadOnlyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DepartmentReadDto? Department { get; set; }
        public IEnumerable<DeveloperReadDto> Developers { get; set; } = Enumerable.Empty<DeveloperReadDto>();
    }
}
