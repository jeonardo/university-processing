using Ardalis.Specification;

namespace UniversityProcessing.Repository.Base;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}