﻿namespace Fiap.Api.VerdeVolt.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  
        public string? Role { get; set; }
    }
}
