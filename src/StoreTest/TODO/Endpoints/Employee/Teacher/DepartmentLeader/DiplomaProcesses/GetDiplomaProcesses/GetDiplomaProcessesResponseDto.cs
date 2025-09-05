namespace StoreTest.TODO.Endpoints.Employee.GetDiplomaProcesses;

public sealed class GetDiplomaProcessesResponseDto(PagedList<DiplomaProcessDto> list)
{
    public PagedList<DiplomaProcessDto> List { get; set; } = list;
}
