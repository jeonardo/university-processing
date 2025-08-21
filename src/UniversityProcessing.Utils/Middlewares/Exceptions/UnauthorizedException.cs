using System.Net;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares.Exceptions;

public sealed class UnauthorizedException() : HandledException(HttpStatusCode.Forbidden, "Access denied");
