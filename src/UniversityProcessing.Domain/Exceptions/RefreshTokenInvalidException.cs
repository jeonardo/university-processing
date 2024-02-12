using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProcessing.Domain.Exceptions
{
    public class RefreshTokenInvalidException : HandledException
    {
        public RefreshTokenInvalidException()
            : base(HttpStatusCode.BadRequest, "Refresh token is invalid or expired!") { }
    }
}
