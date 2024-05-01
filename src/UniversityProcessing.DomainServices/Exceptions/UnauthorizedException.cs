using System.Net;
using UniversityProcessing.GenericSubdomain.GlobalExceptionHandler.Contracts;

namespace UniversityProcessing.DomainServices.Exceptions;

public sealed class UnauthorizedException() : HandledException(HttpStatusCode.Forbidden, "Access denied");