namespace ComfySelf.Patients.Application.Models.DTOs;

public class CreatePatientDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime Birthday { get; set; }
}
