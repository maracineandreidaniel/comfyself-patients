using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComfySelf.Patients.Application.Models.DTOs;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Services.Abstractions
{
    public interface IPatientService
    {
        public Task CreatePatient(CreatePatientDTO patient, CancellationToken cancellationToken);
        public Task UpdatePatient(UpdatePatientDTO patient, CancellationToken cancellationToken);
        public Task DeletePatient(Guid patientId, CancellationToken cancellationToken);
        public Task<PatientDTO> GetPatientById(Guid patientId, CancellationToken cancellationToken);
        public Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken);
        public Task<List<PatientDTO>> GetAllPatients(CancellationToken cancellationToken);
    }
}
