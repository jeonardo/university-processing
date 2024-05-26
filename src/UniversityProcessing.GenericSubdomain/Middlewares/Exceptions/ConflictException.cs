using System.Net;
using UniversityProcessing.GenericSubdomain.Middlewares.Contracts;

namespace UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;

public sealed class ConflictException(string message) : HandledException(HttpStatusCode.Conflict, message);