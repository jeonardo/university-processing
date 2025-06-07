namespace UniversityProcessing.Application.Features.Users;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? Group { get; set; }
    public int? GraduationYear { get; set; }
    public RoleType RoleType { get; set; }
}