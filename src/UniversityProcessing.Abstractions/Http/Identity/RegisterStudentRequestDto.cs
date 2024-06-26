﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class RegisterStudentRequestDto
{
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required UserRoleIdDto UserRole { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string UserName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 4)]
    public required string Password { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? LastName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? MiddleName { get; set; }

    [StringLength(50, MinimumLength = 1)]
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Birthday { get; set; }

    public Guid? UniversityId { get; set; }

    public Guid? UniversityPositionId { get; set; }
    public Guid? GroupId { get; set; }
}
