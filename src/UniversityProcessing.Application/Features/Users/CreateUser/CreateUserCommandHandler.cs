namespace UniversityProcessing.Application.Features.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService _passwordService;

    public CreateUserCommandHandler(
        IApplicationDbContext context,
        IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Проверка уникальности email
        if (await _context.Users.AnyAsync(u => u.Email.Value == request.Email, cancellationToken))
        {
            throw new ConflictException("Email уже используется");
        }

        // Создание value objects
        var name = new PersonalName(request.FirstName, request.LastName);
        var email = new Email(request.Email);
        var passwordHash = _passwordService.HashPassword(request.Password);

        // Создание пользователя в зависимости от роли
        User user = request.RoleType switch
        {
            RoleType.Student => new Student(
                name,
                email,
                passwordHash,
                request.Group!,
                request.GraduationYear!.Value),

            _ => new Employee(name, email, passwordHash)
        };

        // Добавление роли
        user.AddRole(request.RoleType);

        // Сохранение
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        // Ручной маппинг в DTO
        return MapToDto(user, request.RoleType);
    }

    // Ручной маппер
    private static UserDto MapToDto(User user, RoleType roleType)
    {
        var dto = new UserDto
        {
            Id = user.Id,
            FirstName = user.Name.FirstName,
            LastName = user.Name.LastName,
            FullName = user.Name.FullName,
            Email = user.Email.Value,
            RoleType = roleType,
            IsVerified = user.Status == UserStatus.Verified
        };

        if (user is Student student)
        {
            dto.Group = student.Group;
            dto.GraduationYear = student.GraduationYear;
        }

        return dto;
    }
}
