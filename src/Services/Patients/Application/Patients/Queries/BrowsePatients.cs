﻿using CompanyName.MyProjectName.BuildingBlocks.Abstractions.Pagination;
using CompanyName.MyProjectName.Patients.Application.Patients.DTO;

namespace CompanyName.MyProjectName.Patients.Application.Patients.Queries;

internal class BrowsePatients : PagedQuery<PatientDto>
{
    public int PatientId { get; set; }

    public string Name { get; set; } = string.Empty;
}