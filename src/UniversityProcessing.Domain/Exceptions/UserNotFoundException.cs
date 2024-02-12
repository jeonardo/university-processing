using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProcessing.Domain.Exceptions
{
    public class UserNotFoundException
    {
        private const HttpStatusCode httpStatusCode = HttpStatusCode.NotFound;

        public class ById(Guid id)
            : HandledException(httpStatusCode, $"No user found with id: {id}");

        public class ByUserName(string userName)
            : HandledException(httpStatusCode, $"No user found with username: {userName}");

        public class ByEmail(string email)
            : HandledException(httpStatusCode, $"No user found with email: {email}");
    }
}
