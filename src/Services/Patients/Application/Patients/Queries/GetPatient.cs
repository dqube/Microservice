using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;
using CompanyName.MyProjectName.Patients.Application.Patients.DTO;

namespace CompanyName.MyProjectName.Patients.Application.Patients.Queries;

internal class GetPatient : IQuery<PatientDetailsDto>
{
    public int PatientId { get; set; }
}