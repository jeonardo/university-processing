using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class ConflictException(string message) : HandledException(HttpStatusCode.Conflict, message);
