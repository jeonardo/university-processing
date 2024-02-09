using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProcessing.Domain.Exceptions
{
    public class UserNotFoundException(string userName) : HandledException($"No user found with username: {userName}")
    {
    }
}
