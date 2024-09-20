using System.Net;
using UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

public sealed class UnauthorizedException() : HandledException(HttpStatusCode.Forbidden, "Access denied");
