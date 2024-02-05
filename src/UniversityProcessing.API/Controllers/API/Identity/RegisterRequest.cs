﻿using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Controllers.API.Identity
{
    public record RegisterRequest([Required][MinLength(1)] string UserName,
                                  [Required][MinLength(4)] string Password);
}