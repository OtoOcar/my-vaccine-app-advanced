using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyGroupsController : ControllerBase
    {
        private readonly IFamilyGroupService _service;

        public FamilyGroupsController(IFamilyGroupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetById(id);
            if (response == null) return NotFound(new { message = "Family group not found" });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FamilyGroupRequestDto request)
        {
            var response = await _service.Create(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FamilyGroupRequestDto request)
        {
            var response = await _service.Update(request, id);
            if (response == null) return NotFound(new { message = "Family group not found" });
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound(new { message = "Family group not found" });
            return Ok(new { message = "Family group deleted successfully" });
        }
    }
}