using System.Net;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares.Exceptions;

public sealed class InvalidTokenException() : HandledException(HttpStatusCode.Unauthorized, "Token is invalid or expired");
