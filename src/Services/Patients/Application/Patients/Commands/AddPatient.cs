using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;
using CompanyName.MyProjectName.Patients.Domain.Patients.ValueObjects;

namespace CompanyName.MyProjectName.Patients.Application.Patients.Commands;

internal record AddPatient(PatientId PatientId, string Name) : ICommand
{
}
