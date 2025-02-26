using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAuthApp.Data;
using MyAuthApp.Services;
using System.Threading.Tasks;

namespace MyAuthApp.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;

        public WorkshopsController(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workshops = await _workshopService.GetAllAsync();
            return Ok(workshops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workshop = await _workshopService.GetByIdAsync(id);
            if (workshop == null) return NotFound();
            return Ok(workshop);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Workshop workshop)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdWorkshop = await _workshopService.CreateAsync(workshop);
            return CreatedAtAction(nameof(GetById), new { id = createdWorkshop.Id }, createdWorkshop);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Workshop updatedWorkshop)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _workshopService.UpdateAsync(id, updatedWorkshop);
            if (!success) return NotFound();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _workshopService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
