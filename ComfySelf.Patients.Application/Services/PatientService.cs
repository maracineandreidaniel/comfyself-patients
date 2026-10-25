using ComfySelf.Patients.Application.Models.DTOs;
using ComfySelf.Patients.Application.Repositories.Abstractions;
using ComfySelf.Patients.Application.Services.Abstractions;
using ComfySelf.Patients.Domain.Models;

namespace ComfySelf.Patients.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository) => _patientRepository = patientRepository;

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
        Patient? patient = await _patientRepository
            .GetPatientById(patientId, cancellationToken) ?? throw new KeyNotFoundException(
                $"Patient with id '{patientId}' was not found.");

        await _patientRepository.DeletePatient(patientId, cancellationToken);
    }

    public async Task<bool> ExistsPatient(Guid patientId, CancellationToken cancellationToken) => await _patientRepository.ExistsPatient(patientId, cancellationToken);

    public async Task<List<PatientDTO>> GetAllPatients(CancellationToken cancellationToken)
    {
        List<Patient> patients = await _patientRepository.GetAllPatients(cancellationToken);

        return patients
       .Select(MapToDto)
       .ToList();
    }

    public async Task<PatientDTO> GetPatientById(Guid patientId, CancellationToken cancellationToken)
    {
        Patient? patient = await _patientRepository
            .GetPatientById(patientId, cancellationToken) ?? throw new KeyNotFoundException(
                $"Patient with id '{patientId}' was not found.");

        return MapToDto(patient);
    }

    public async Task UpdatePatient(UpdatePatientDTO patient, CancellationToken cancellationToken)
    {
        Patient updatedPatient = await _patientRepository.GetPatientById(patient.IdToUpdate, cancellationToken) ?? throw new KeyNotFoundException(
                $"Patient with id '{patient.IdToUpdate}' was not found.");

        patient.Description = patient.Description;
        patient.Birthday = patient.Birthday;
        patient.Name = patient.Name;

        await _patientRepository.UpdatePatient((Patient)updatedPatient, cancellationToken);
    }

    private PatientDTO MapToDto(Patient patient) => new PatientDTO
    {
        Id = patient.Id,
        Name = patient.Name,
        Birthday = patient.Birthday,
        Description = patient.Description
    };
}
