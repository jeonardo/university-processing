using System;
using System.Net;

namespace UniversityProcessing.Domain.Exceptions;

public class DuplicateException(string message) : HandledException(HttpStatusCode.BadRequest,message)
{
}
