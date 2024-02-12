using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProcessing.Domain.Entities;

namespace UniversityProcessing.Infrastructure.Repositories
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
