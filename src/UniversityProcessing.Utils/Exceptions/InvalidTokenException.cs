using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class InvalidTokenException() : HandledException(HttpStatusCode.Unauthorized, "Token is invalid or expired");
