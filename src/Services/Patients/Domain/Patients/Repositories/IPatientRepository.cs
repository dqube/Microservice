using CompanyName.MyProjectName.Patients.Domain.Patients.Entities;
using CompanyName.MyProjectName.Patients.Domain.Patients.ValueObjects;

namespace CompanyName.MyProjectName.Patients.Domain.Patients.Repositories;

internal interface IPatientRepository
{
    Task<Patient> GetAsync(PatientId id, CancellationToken cancellationToken = default);

    Task AddAsync(Patient customer, CancellationToken cancellationToken = default);

    Task UpdateAsync(Patient customer, CancellationToken cancellationToken = default);
}
