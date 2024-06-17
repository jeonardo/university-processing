using UniversityProcessing.Abstractions.Http.Universities.User;

namespace UniversityProcessing.DomainServices.Features.Users.Get.Contracts;

public sealed record UserGetQueryResponse(UserDto User);
