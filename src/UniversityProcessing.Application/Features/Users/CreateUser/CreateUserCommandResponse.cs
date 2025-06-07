namespace UniversityProcessing.Application.Features.Users;

public class CreateUserCommandResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public RoleType RoleType { get; set; }
    public bool IsVerified { get; set; }
    public string? Group { get; set; }
    public int? GraduationYear { get; set; }
}