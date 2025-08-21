using System.Net;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares.Exceptions;

public sealed class ConflictException(string message) : HandledException(HttpStatusCode.Conflict, message);
