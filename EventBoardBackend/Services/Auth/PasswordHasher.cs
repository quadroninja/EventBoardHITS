﻿using Microsoft.AspNetCore.Identity;

namespace EventBoardBackend.Services.Auth
{
    public class PasswordHasher
    {
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword); 
        }
    }
}
