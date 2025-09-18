using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Routing;
using UniversityProcessing.Domain;
using UniversityProcessing.Infrastructure.Interfaces.Repositories;
using UniversityProcessing.Utils.Endpoints;
using UniversityProcessing.Utils.Exceptions;
using UniversityProcessing.Utils.Filters;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

internal sealed class Endpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var type = typeof(Endpoint);
        app
            .MapGet(NamespaceService.GetEndpointRoute(type), Handle)
            .WithTags(NamespaceService.GetEndpointTags(type))
            .RequireAuthorization()
            .AddEndpointFilter<ValidationFilter<RequestDto>>();
    }

    private static async Task<ResponseDto> Handle(
        [AsParameters] RequestDto request,
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

        UserDto? head = null;
        var deaneries = new List<UserDto>();

        foreach (var deanery in faculty.Deaneries)
        {
            if (faculty.HeadUserId.HasValue && faculty.HeadUserId.Value == deanery.Id)
            {
                head = new UserDto(
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
                new UserDto(
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

        return new ResponseDto(faculty.Id, faculty.Name, faculty.ShortName, head, deaneries);
    }
}
