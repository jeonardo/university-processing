using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class AccessDeniedException(string message) : HandledException(HttpStatusCode.Forbidden, message);
