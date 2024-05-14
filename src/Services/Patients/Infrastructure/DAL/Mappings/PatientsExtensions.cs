﻿using CompanyName.MyProjectName.Patients.Application.Patients.DTO;
using CompanyName.MyProjectName.Patients.Domain.Patients.Entities;

namespace CompanyName.MyProjectName.Patients.Infrastructure.DAL.Mappings;

internal static class PatientsExtensions
{
    public static PatientDto AsDto(this Patient patient)
        => patient.Map<PatientDto>();

    public static PatientDetailsDto AsDetailsDto(this Patient patient)
    {
        var dto = patient.Map<PatientDetailsDto>();

        return dto;
    }

    private static T Map<T>(this Patient patient)
        where T : PatientDto, new()
        => new()
        {
            PatientId = patient.Id,
            Name = patient.Name,

            // CreatedAt = patient.CreatedAt
        };
}