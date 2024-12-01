namespace UniversityProcessing.API.Endpoints.Admin.GetUsers;

public sealed class GetUsersRequestDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; } = string.Empty;
    public bool Desc { get; set; }
}
