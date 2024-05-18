using System.Net;
using UniversityProcessing.GenericSubdomain.ExceptionHandlers.Contracts;

namespace UniversityProcessing.GenericSubdomain.Exceptions;

public sealed class ConflictException(string message) : HandledException(HttpStatusCode.Conflict, message);