namespace UniversityProcessing.API.Endpoints.Common.GetUniversities;

public sealed class GetUniversitiesRequestDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string OrderBy { get; set; } = string.Empty;
    public bool Desc { get; set; }
}
