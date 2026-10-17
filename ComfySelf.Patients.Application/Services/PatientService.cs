using ComfySelf.Patients.Application.Models.DTOs;
using ComfySelf.Patients.Application.Repositories.Abstractions;
using ComfySelf.Patients.Application.Services.Abstractions;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task CreatePatient(CreatePatientDTO patient, CancellationToken cancellationToken)
        {
            var patientToBeAdded = new Patient
            {
                Id = Guid.NewGuid(),
                Name = patient.Name,
                Birthday = patient.Birthday,
                Description = patient.Description
            };
           await _patientRepository.CreatePatient(patientToBeAdded, cancellationToken);
        }

        public async Task DeletePatient(Guid patientId, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository
                .GetPatientById(patientId, cancellationToken);

            if (patient is null)
            {
                throw new KeyNotFoundException(
                    $"Patient with id '{patientId}' was not found.");
            }

            await _patientRepository.DeletePatient(patientId, cancellationToken);
        }

        public async Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken)
        {
            return await _patientRepository.ExistsPatient(patientId, cancellationToken);
        }

        public async Task<List<PatientDTO>> GetAllPatients(CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllPatients(cancellationToken);

            return patients
           .Select(MapToDto)
           .ToList();
        }

        public async Task<PatientDTO> GetPatientById(Guid patientId, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository
                .GetPatientById(patientId, cancellationToken);

            if (patient is null)
            {
                throw new KeyNotFoundException(
                    $"Patient with id '{patientId}' was not found.");
            }

            return MapToDto(patient);
        }

        public async Task UpdatePatient(UpdatePatientDTO patientRequest, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientById(patientRequest.IdToUpdate, cancellationToken);

            if (patient is null)
            {
                throw new KeyNotFoundException(
                    $"Patient with id '{patientRequest.IdToUpdate}' was not found.");
            }

            patient.Description = patientRequest.Description;
            patient.Birthday = patientRequest.Birthday;
            patient.Name = patientRequest.Name;

            await _patientRepository.UpdatePatient(patient, cancellationToken);
        }

        private PatientDTO MapToDto(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Birthday = patient.Birthday,
                Description = patient.Description
            };
                
        }
    }
}
