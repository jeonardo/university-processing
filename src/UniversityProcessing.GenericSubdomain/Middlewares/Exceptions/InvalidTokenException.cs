using System.Net;
using UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

public sealed class InvalidTokenException() : HandledException(HttpStatusCode.BadRequest, "Token is invalid or expired");
