﻿namespace FinSystem.Models;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiredHours { get; set; }
}