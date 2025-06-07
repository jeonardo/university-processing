namespace UniversityProcessing.Core.Interfaces.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);

    Task<bool> IsEmailUniqueAsync(string email);

    Task<IEnumerable<User>> GetUsersByRoleAsync(RoleType role);
}
