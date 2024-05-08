using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;
using NotFoundException = UniversityProcessing.DomainServices.Exceptions.NotFoundException;

namespace UniversityProcessing.DomainServices.Features.Universities.Get;

public sealed class UniversityGetQueryHandler(IReadRepository<University> repository)
    : IRequestHandler<UniversityGetQueryRequest, UniversityGetQueryResponse>
{
    public async Task<UniversityGetQueryResponse> Handle(
        UniversityGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(University)} with id = {request.Id} not found");

        return new UniversityGetQueryResponse(UniversityConverter.ToDto(record));
    }
}