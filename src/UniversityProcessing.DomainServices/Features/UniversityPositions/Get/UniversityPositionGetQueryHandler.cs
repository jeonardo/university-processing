using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get;

internal sealed class UniversityPositionGetQueryHandler(IRepository<UniversityPosition> repository)
    : IRequestHandler<UniversityPositionGetQueryRequest, UniversityPositionGetQueryResponse>
{
    public async Task<UniversityPositionGetQueryResponse> Handle(UniversityPositionGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(UniversityPosition)} with id = {request.Id} not found");

        return new UniversityPositionGetQueryResponse(UniversityPositionConverter.ToDto(record));
    }
}