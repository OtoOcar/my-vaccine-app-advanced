using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;

[Route("api/[controller]")]
[ApiController]
public class AllergiesController : ControllerBase
{
    private readonly IAllergyService _allergyService;

    public AllergiesController(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _allergyService.GetAll();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _allergyService.GetById(id);
        if (response == null) return NotFound(new { message = "Allergy not found" });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AllergyRequestDto request)
    {
        var response = await _allergyService.Create(request);
        return Ok(response);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AllergyRequestDto request)
    {
        var response = await _allergyService.Update(request, id);
        if (response == null) return NotFound(new { message = "Allergy not found" });
        return Ok(response);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _allergyService.Delete(id);
        if (!deleted) return NotFound(new { message = "Allergy not found" });
        return Ok(new { message = "Allergy deleted successfully" });
    }
}