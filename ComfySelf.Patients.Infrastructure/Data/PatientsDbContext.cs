using ComfySelf.Patients.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ComfySelf.Patients.Infrastructure.Data;

public class PatientsDbContext(DbContextOptions<PatientsDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients { get; set; }
}
