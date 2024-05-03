using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Base;

public sealed class EfRepository<T>(DbContext dbContext) : RepositoryBase<T>(dbContext), IEfRepository<T>
    where T : class, IAggregateRoot;