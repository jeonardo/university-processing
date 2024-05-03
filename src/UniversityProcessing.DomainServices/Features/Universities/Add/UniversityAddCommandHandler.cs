using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.Universities;
using UniversityProcessing.DomainServices.Features.Universities.Add.Contracts;

namespace UniversityProcessing.DomainServices.Features.Universities.Add;

internal sealed class UniversityAddCommandHandler(IRepository<University> repository)
    : IRequestHandler<UniversityAddCommandRequest, UniversityAddCommandResponse>
{
    public Task<UniversityAddCommandResponse> Handle(
        UniversityAddCommandRequest request,
        CancellationToken cancellationToken)
    {
        var newEntity = new University(request.Name, request.ShortName);
        await repository.AddAsync(newEntity);
    }
}