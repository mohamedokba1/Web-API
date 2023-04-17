using CoursesTikects.DAL;
using Microsoft.AspNetCore.Mvc;
using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.BL.Managers;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.BL.Dtos;

namespace CoursesTikects.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketManager _ticketManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IDeveloperManager _developerManager;
        public TicketController(
            ITicketManager ticketManager,
            IDepartmentManager departmentManager,
            IDeveloperManager developerManager)
        {
            _ticketManager = ticketManager;
            _departmentManager = departmentManager;
            _developerManager = developerManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ticketManager.GetTicketDetails());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Ticket? ticket = await _ticketManager.GetByID(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketDto value)
        {
            Department? dept = await _departmentManager.GetByID(value.Dept_Id);
            if (dept == null) return BadRequest("Department Doesn't Exist");

            var result = await _developerManager.GetRange(value.DevelopersIds);

            if (result.Count() != value.DevelopersIds.Count()) return BadRequest("Developers Are Not Valid");
            Ticket ticket = new Ticket()
            {
                Title = value.Title,
                description = value.Description,
                Department = dept,
                Dept_Id = value.Dept_Id,
                Developers = new HashSet<Developer>()
            };
            foreach (Developer developer in result)
            {
                ticket.Developers.Add(developer);
            }

            await _ticketManager.Add(ticket);
            await _ticketManager.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket value)
        {
            if (id != value.Id) return BadRequest();
            _ticketManager.Update(value);
            await _ticketManager.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Ticket entity)
        {
            _ticketManager.Delete(entity);
            return NoContent();
        }
    }
}
