using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.List.Contracts;

public sealed record UniversityGetCommandRequest(
    int Offset,
    int Count,
    string OrderBy,
    bool Desc) : IRequest<UniversityGetCommandResponse>;