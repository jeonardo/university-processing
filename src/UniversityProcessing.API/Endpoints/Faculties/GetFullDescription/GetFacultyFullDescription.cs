using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;
using UniversityProcessing.Utils.Routing;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

internal sealed class GetFacultyFullDescription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(GetFacultyFullDescription);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization(x => x.RequireRole(nameof(UserRoleType.Admin)))
            .AddEndpointFilter<ValidationFilter<GetFacultyFullDescriptionRequestDto>>();
    }

    private static async Task<GetFacultyFullDescriptionResponseDto> Handle(
        [AsParameters] GetFacultyFullDescriptionRequestDto request,
        [FromServices] IEfRepository<Faculty> repository,
        CancellationToken cancellationToken)
    {
        var faculty = await repository.TypedDbContext
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Include(x => x.Deaneries)
                .ThenInclude(x => x.UniversityPosition)
                .SingleOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException("Faculty not found");

        FacultyFullDescriptionUserDto? head = null;
        var deaneries = new List<FacultyFullDescriptionUserDto>();

        foreach (var deanery in faculty.Deaneries)
        {
            if (faculty.HeadUserId.HasValue && faculty.HeadUserId.Value == deanery.Id)
            {
                head = new FacultyFullDescriptionUserDto(
                    deanery.Id,
                    deanery.FirstName,
                    deanery.LastName,
                    deanery.MiddleName,
                    deanery.Email,
                    deanery.PhoneNumber,
                    deanery.UniversityPosition.Name,
                    deanery.Blocked,
                    deanery.Approved);
            }

            deaneries.Add(
                new FacultyFullDescriptionUserDto(
                    deanery.Id,
                    deanery.FirstName,
                    deanery.LastName,
                    deanery.MiddleName,
                    deanery.Email,
                    deanery.PhoneNumber,
                    deanery.UniversityPosition.Name,
                    deanery.Blocked,
                    deanery.Approved));
        }

        return new GetFacultyFullDescriptionResponseDto(faculty.Id, faculty.Name, faculty.ShortName, head, deaneries);
    }
}
