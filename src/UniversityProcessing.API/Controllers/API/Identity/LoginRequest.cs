﻿using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Controllers.API.Identity
{
    public record LoginRequest([Required][MinLength(1)] string UserName,
                               [Required][MinLength(4)] string Password);
}