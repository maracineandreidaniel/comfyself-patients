using ComfySelf.Patients.Application.Repositories.Abstractions;
using ComfySelf.Patients.Domain.Models;
using ComfySelf.Patients.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ComfySelf.Patients.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly PatientsDbContext _dbContext;

        public PatientRepository(PatientsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePatient(Patient patient, CancellationToken cancellationToken)
        {
            await _dbContext.Patients.AddAsync(patient, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePatient(Guid patientId, CancellationToken cancellationToken)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);

            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken)
        {
            return await _dbContext.Patients.AnyAsync(x => x.Id == patientId, cancellationToken);
        }

        public async Task<List<Patient>> GetAllPatients(CancellationToken cancellationToken)
        {
            var patients = await _dbContext.Patients.AsNoTracking().ToListAsync(cancellationToken);
            return patients;
        }

        public async Task<Patient> GetPatientById(Guid patientId, CancellationToken cancellationToken)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);
            
            return patient;
        }

        public async Task UpdatePatient(Patient patient, CancellationToken cancellationToken)
        {
                _dbContext.Update(patient);
                await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
