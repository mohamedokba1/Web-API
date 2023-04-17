using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesTikects.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperManager _developerManager;

        public DeveloperController(IDeveloperManager developerManager)
        {
            _developerManager = developerManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _developerManager.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Developer? ticket = await _developerManager.GetByID(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Developer value)
        {
            await _developerManager.Add(value);
            await _developerManager.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Developer value)
        {
            if (id != value.Id) return BadRequest();
            _developerManager.Update(value);
            await _developerManager.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Developer entity)
        {
            _developerManager.Delete(entity);
            return NoContent();
        }
    }
}
