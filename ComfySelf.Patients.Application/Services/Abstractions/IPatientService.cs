using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComfySelf.Patients.Application.Models.DTOs;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Services.Abstractions;

public interface IPatientService
{
    Task CreatePatient(CreatePatientDTO patient, CancellationToken cancellationToken);
    Task UpdatePatient(UpdatePatientDTO patient, CancellationToken cancellationToken);
    Task DeletePatient(Guid patientId, CancellationToken cancellationToken);
    Task<PatientDTO> GetPatientById(Guid patientId, CancellationToken cancellationToken);
    Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken);
    Task<List<PatientDTO>> GetAllPatients(CancellationToken cancellationToken);
}
