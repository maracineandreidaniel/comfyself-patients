using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Repositories.Abstractions;

public interface IPatientRepository
{
    Task CreatePatient(Patient patient, CancellationToken cancellationToken);
    Task UpdatePatient(Patient patient, CancellationToken cancellationToken);
    Task DeletePatient(Guid patientId, CancellationToken cancellationToken);
    Task<Patient?> GetPatientById(Guid patientId, CancellationToken cancellationToken);
    Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken);
    Task<List<Patient>> GetAllPatients(CancellationToken cancellationToken);
}
