using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Specialties.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Get;

internal sealed class SpecialtyGetQueryHandler(IEfReadRepository<Specialty> repository)
    : IRequestHandler<SpecialtyGetQueryRequest, SpecialtyGetQueryResponse>
{
    public async Task<SpecialtyGetQueryResponse> Handle(
        SpecialtyGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new SpecialtyGetQueryResponse(SpecialtyConverter.ToDto(record));
    }
}