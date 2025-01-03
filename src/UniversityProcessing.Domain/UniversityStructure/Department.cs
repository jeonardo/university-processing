﻿using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Domain.Bases;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.GenericSubdomain.Identity;

namespace UniversityProcessing.Domain.UniversityStructure;

public sealed class Department : BaseEntity, IHasId
{
    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string Name { get; private set; } = null!;

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string ShortName { get; private set; } = null!;

    public Guid? FacultyId { get; private set; }

    public Faculty? Faculty { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    // Parameterless constructor used by EF Core
    // ReSharper disable once UnusedMember.Local
    private Department()
    {
    }

    public static Department Create(string name, string shortName, Guid? facultyId = null)
    {
        return new Department
        {
            Name = name,
            ShortName = shortName,
            FacultyId = facultyId
        };
    }
}
