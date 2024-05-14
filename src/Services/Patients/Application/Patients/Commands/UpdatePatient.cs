using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;

namespace CompanyName.MyProjectName.Patients.Application.Patients.Commands;

internal record UpdatePatient(int PatientId, string Name) : ICommand
{
}
