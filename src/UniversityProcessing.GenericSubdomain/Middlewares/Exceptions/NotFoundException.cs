using System.Net;
using UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

public sealed class NotFoundException(string message) : HandledException(HttpStatusCode.NotFound, message);
