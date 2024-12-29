using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.API.Endpoints.Admin.Departments.Create;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1")]
public class Controller1 : Controller
{
    [HttpPost]
    public Task Todo(
        [FromBody] CreateDepartmentRequestDto request,
        [FromServices] IEfRepository<Department> repository,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
