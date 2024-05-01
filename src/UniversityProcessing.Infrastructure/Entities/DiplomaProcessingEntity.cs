using UniversityProcessing.Infrastructure.Entities.Base;
using UniversityProcessing.Repository.Base;

namespace UniversityProcessing.Infrastructure.Entities;

public class DiplomaProcessingEntity : BaseEntity, IAggregateRoot
{
    public required Guid SecretaryId { get; set; }

    public required ICollection<string> RequiredTitles { get; set; }

    public virtual required ICollection<GraduateWorkEntity> GraduateWorks { get; set; }

    public virtual required ICollection<StudentEntity> Students { get; set; }

    public virtual required ICollection<EmployeeEntity> Employees { get; set; }
}