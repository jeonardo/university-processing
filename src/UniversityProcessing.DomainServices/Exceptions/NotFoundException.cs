using System.Net;
using UniversityProcessing.GenericSubdomain.GlobalExceptionHandler.Contracts;

namespace UniversityProcessing.DomainServices.Exceptions;

public sealed class NotFoundException(string message) : HandledException(HttpStatusCode.NotFound, message);