using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

public sealed class RequestDto : BaseGetListQueryParameters
{
    public Guid? FacultyId { get; set; }
}
