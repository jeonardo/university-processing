using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class NotFoundException(string message) : HandledException(HttpStatusCode.NotFound, message);
