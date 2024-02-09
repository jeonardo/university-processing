using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProcessing.Domain.Exceptions
{
    Set status code and next exception and result handling
    public class HandledException(string message) : Exception(message)
    {
    }
}
