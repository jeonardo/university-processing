using System.Net;

namespace UniversityProcessing.Utils.Exceptions;

public sealed class AccessDeniedException(string message = "Action not allowed") : HandledException(HttpStatusCode.Forbidden, message);
