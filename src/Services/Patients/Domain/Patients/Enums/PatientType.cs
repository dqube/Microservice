using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Kernel;

namespace CompanyName.MyProjectName.Patients.Domain.Patients.Enums;

internal class PatientType : Enumeration
{
    public static readonly PatientType OutPatient = new(1, "OutPatient");
    public static readonly PatientType InPatient = new(2, "InPatient");

    public PatientType(int id, string name)
        : base(id, name)
    {
    }
}
