﻿using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Auth.Login;

public sealed class LoginRequestDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
