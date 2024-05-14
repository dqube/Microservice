using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Abstractions;

namespace CompanyName.MyProjectName.Patients.Application.Patients.Events;

internal record PatientAdded(int PatientId, string Name) : IEvent;