using MediatR;
using UniversityProcessing.DomainServices.Features.Universities.List.Contracts;
using UniversityProcessing.Repository.Queries;

namespace UniversityProcessing.DomainServices.Features.Universities.List;

public sealed class UniversityGetCommandHandler(IUniversityQueries queries)
    : IRequestHandler<UniversityGetCommandRequest, UniversityGetCommandResponse>
{
    public async Task<UniversityGetCommandResponse> Handle(
        UniversityGetCommandRequest request,
        CancellationToken cancellationToken)
    {
        var records = await queries.ListAsync(request.Offset, request.Count, request.OrderBy, request.Desc, cancellationToken);
        return new UniversityGetCommandResponse(records);
    }
}