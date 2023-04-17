using CoursesTikects.DAL.Data.Models;
using Microsoft.AspNetCore.Mvc;
using CoursesTikects.BL.Managers.Inertfaces;

namespace CoursesTikects.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        public readonly IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentManager.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Department? ticket = await _departmentManager.GetByID(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }
        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult GetDeptDetails(int id)
        {
            var dept = _departmentManager.GetDepartmentDetails(id);
            return dept == null ? NotFound() : Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department value)
        {
            await _departmentManager.Add(value);
            await _departmentManager.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Department value)
        {
            if (id != value.Id) return BadRequest();
            Department? department = await _departmentManager.GetByID(id);
            if (department == null) return NotFound();
            department.Name = value.Name;
            await _departmentManager.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Department entity)
        {
            _departmentManager.Delete(entity);
            await _departmentManager.SaveChanges();
            return NoContent();
        }

    }
}
