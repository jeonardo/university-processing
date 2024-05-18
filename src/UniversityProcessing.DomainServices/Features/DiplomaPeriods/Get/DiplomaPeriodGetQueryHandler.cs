using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get.Contracts;
using UniversityProcessing.GenericSubdomain.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Get;

internal sealed class DiplomaPeriodGetQueryHandler(IEfReadRepository<DiplomaPeriod> repository)
    : IRequestHandler<DiplomaPeriodGetQueryRequest, DiplomaPeriodGetQueryResponse>
{
    public async Task<DiplomaPeriodGetQueryResponse> Handle(DiplomaPeriodGetQueryRequest request, CancellationToken cancellationToken)
    {
var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new DiplomaPeriodGetQueryResponse(DiplomaPeriodConverter.ToDto(record));
    }
}