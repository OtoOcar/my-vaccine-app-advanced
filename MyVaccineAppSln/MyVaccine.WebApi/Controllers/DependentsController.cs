using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DependentsController : ControllerBase
{
    private readonly IDependentService _dependentService;
    private readonly IValidator<DependentRequestDto> _validator;

    public DependentsController(IDependentService dependentService, IValidator<DependentRequestDto> validator)
    {
        _dependentService = dependentService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dependents = await _dependentService.GetAll();
        return Ok(dependents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dependents = await _dependentService.GetById(id);
        return Ok(dependents);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(DependentRequestDto dependentsDto)
    {
        var validationResult = await _validator.ValidateAsync(dependentsDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var dependents = await _dependentService.Add(dependentsDto);
        return Ok(dependents);
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDependent(int id, [FromBody] DependentRequestDto request)
    {
        if (request == null || id <= 0)
            return BadRequest(new { message = "Datos inválidos" });

        var response = await _dependentService.Update(request, id);

        if (response == null)
            return NotFound(new { message = "Dependiente no encontrado" });

        return Ok(response);
    }


    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDependent(int id)
    {
        if (id <= 0)
            return BadRequest(new { message = "Id inválido" });

        var deleted = await _dependentService.Delete(id);

        if (deleted == null)
            return NotFound(new { message = "Dependiente no encontrado" });

        return Ok(new { message = "Dependiente eliminado correctamente" });
    }

}
