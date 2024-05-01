using UniversityProcessing.Domain;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Repository.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> Get(string userName, CancellationToken cancellationToken);
}