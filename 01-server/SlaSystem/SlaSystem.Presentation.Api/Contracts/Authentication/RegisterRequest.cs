﻿namespace SlaSystem.Presentation.Api.Contracts.Authentication;

public class RegisterRequest
{
    public string UserName { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
}