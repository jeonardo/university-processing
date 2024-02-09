using System;

namespace UniversityProcessing.Domain.Exceptions;

public class DuplicateException(string message) : HandledException(message)
{
}
