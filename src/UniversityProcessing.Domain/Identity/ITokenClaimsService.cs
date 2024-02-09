using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProcessing.Domain.DTOs;

namespace UniversityProcessing.Domain.Identity
{
    public interface ITokenClaimsService
    {
        Task<Result<Token>> RefreshAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
    }
}
