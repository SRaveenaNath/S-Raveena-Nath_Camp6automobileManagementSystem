using automobileManagementSystem.Model;
using automobileManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace automobileManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoPartsController : ControllerBase
    {
        private readonly IAutoPartsRepository _repository;

        public AutoPartsController(IAutoPartsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParts()
        {
            var parts = await _repository.GetAllPartsAsync();
            return Ok(parts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartById(int id)
        {
            var part = await _repository.GetPartByIdAsync(id);
            if (part == null) return NotFound();
            return Ok(part);
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(AutoPart part)
        {
            var createdPart = await _repository.AddPartAsync(part);
            return CreatedAtAction(nameof(GetPartById), new { id = createdPart.PartId }, createdPart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart(int id, AutoPart part)
        {
            if (id != part.PartId) return BadRequest();

            var updatedPart = await _repository.UpdatePartAsync(part);
            return Ok(updatedPart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(int id)
        {
            var result = await _repository.DeletePartAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }

}
