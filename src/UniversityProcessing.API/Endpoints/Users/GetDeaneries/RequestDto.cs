using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetDeaneries;

public sealed class RequestDto : BaseGetListQueryParameters
{
    public long? FacultyId { get; set; }
}
