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
    Task CreatePatient(CreatePatientDto patient, CancellationToken cancellationToken);
    Task UpdatePatient(UpdatePatientDto patient, CancellationToken cancellationToken);
    Task DeletePatient(Guid patientId, CancellationToken cancellationToken);
    Task<PatientDto> GetPatientById(Guid patientId, CancellationToken cancellationToken);
    Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken);
    Task<List<PatientDto>> GetAllPatients(CancellationToken cancellationToken);
}
