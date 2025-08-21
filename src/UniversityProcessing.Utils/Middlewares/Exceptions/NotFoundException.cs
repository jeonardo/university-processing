using System.Net;
using UniversityProcessing.Utils.Middlewares.Contracts;

namespace UniversityProcessing.Utils.Middlewares.Exceptions;

public sealed class NotFoundException(string message) : HandledException(HttpStatusCode.NotFound, message);
