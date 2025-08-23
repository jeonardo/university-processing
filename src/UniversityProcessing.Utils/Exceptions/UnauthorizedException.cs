using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class UnauthorizedException() : HandledException(HttpStatusCode.Forbidden, "Access denied");
