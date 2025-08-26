using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Auth.Info;

public sealed class InfoResponseDto(
    Guid userId,
    UserRoleTypeDto role,
    bool approved,
    bool blocked,
    string firstName,
    string lastName,
    string? middleName,
    string? userName,
    string? faculty,
    string? department,
    string? email,
    string? position,
    string? phoneNumber,
    string? speciality,
    string? groupNumber)
{
    public Guid UserId { get; set; } = userId;
    public UserRoleTypeDto Role { get; set; } = role;
    public bool Approved { get; set; } = approved;
    public bool Blocked { get; set; } = blocked;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string? MiddleName { get; set; } = middleName;
    public string? UserName { get; set; } = userName;
    public string? Faculty { get; set; } = faculty;
    public string? Department { get; set; } = department;
    public string? Email { get; set; } = email;
    public string? Position { get; set; } = position;
    public string? PhoneNumber { get; set; } = phoneNumber;
    public string? Speciality { get; set; } = speciality;
    public string? GroupNumber { get; set; } = groupNumber;
}
