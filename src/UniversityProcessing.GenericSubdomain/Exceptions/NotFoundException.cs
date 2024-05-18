using System.Net;
using UniversityProcessing.GenericSubdomain.ExceptionHandlers.Contracts;

namespace UniversityProcessing.GenericSubdomain.Exceptions;

public sealed class NotFoundException(string message) : HandledException(HttpStatusCode.NotFound, message);