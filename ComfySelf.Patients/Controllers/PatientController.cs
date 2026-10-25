using ComfySelf.Patients.Application.Models.DTOs;
using ComfySelf.Patients.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ComfySelf.Patients.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService) => _patientService = patientService;

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<PatientDto>>> GetAll(
   CancellationToken cancellationToken)
    {
        List<PatientDto> patients = await _patientService.GetAllPatients(
            cancellationToken);

        return Ok(patients);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PatientDto>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        PatientDto? patient = await _patientService.GetPatientById(
            id,
            cancellationToken);

        if (patient is null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpGet("ExistsPatient/{id:guid}")]
    public async Task<ActionResult<PatientDto>> ExistsPatient(
        Guid id,
        CancellationToken cancellationToken)
    {
        bool result = await _patientService.ExistsPatient(
            id,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PatientDto>> Create(
        CreatePatientDto dto,
        CancellationToken cancellationToken)
    {
       await _patientService.CreatePatient(
            dto,
            cancellationToken);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdatePatientDto dto,
        CancellationToken cancellationToken)
    {
      await  _patientService.UpdatePatient(
            dto,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
       await  _patientService.DeletePatient(
            id,
            cancellationToken);

        return NoContent();
    }

}
