using System.Net;
using UniversityProcessing.GenericSubdomain.ExceptionHandlers.Contracts;

namespace UniversityProcessing.GenericSubdomain.Exceptions;

public sealed class InvalidTokenException() : HandledException(HttpStatusCode.BadRequest, "Token is invalid or expired");