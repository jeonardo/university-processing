using System.Net;
using UniversityProcessing.GenericSubdomain.GlobalExceptionHandler.Contracts;

namespace UniversityProcessing.DomainServices.Exceptions;

public sealed class InvalidTokenException() : HandledException(HttpStatusCode.BadRequest, "Token is invalid or expired");