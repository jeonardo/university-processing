using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

public sealed class GetDeaneriesRequestDto : BaseGetListQueryParameters
{
    public Guid? FacultyId { get; set; }
}
