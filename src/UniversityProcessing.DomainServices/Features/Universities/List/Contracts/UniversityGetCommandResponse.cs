using UniversityProcessing.Abstractions.Http.Universities;

namespace UniversityProcessing.DomainServices.Features.Universities.List.Contracts;

public sealed record UniversityGetCommandResponse(UniversityDto[] Universities);