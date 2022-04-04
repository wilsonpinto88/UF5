﻿using ProjetoFinal.Models;


    public interface IJWTService
    {
        string GenerateToken(string key, string issuer, string audience, UserViewModel user);
        bool IsTokenValid(string key, string issuer, string audience, string token);

        public string GetJWTTokenClaim(string token);
    }

