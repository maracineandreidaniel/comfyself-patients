using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Repositories.Abstractions
{
    public interface IPatientRepository
    {
        public Task CreatePatient(Patient patient, CancellationToken cancellationToken);
        public Task UpdatePatient(Patient patient, CancellationToken cancellationToken);
        public Task DeletePatient(Guid patientId, CancellationToken cancellationToken);
        public Task<Patient> GetPatientById(Guid patientId, CancellationToken cancellationToken);
        public Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken);
        public Task<List<Patient>> GetAllPatients(CancellationToken cancellationToken);
    }
}
