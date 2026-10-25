namespace ComfySelf.Patients.Domain.Models;

public class Patient
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime Birthday { get; set; }
}
