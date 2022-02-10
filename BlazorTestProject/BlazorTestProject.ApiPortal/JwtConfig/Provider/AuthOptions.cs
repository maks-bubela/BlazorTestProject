﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BlazorTestProject.ApiPortal.Interfaces;
using BlazorTestProject.ApiPortal.JwtConfig.JwtSettings;
using BlazorTestProject.BLL.DTO;
using Microsoft.Extensions.Options;

namespace BlazorTestProject.ApiPortal.JwtConfig.Provider
{
    public class AuthOptions : IAuthOptions
    {
        private readonly IOptions<JwtSetting> _config;

        public AuthOptions(IOptions<JwtSetting> config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
        }
        public string GetSymmetricSecurityKey(TokenSettingsDTO settingsDto)
        {
            var now = DateTime.UtcNow;
            var jwtConfig = _config.Value;
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Key));
            var jwt = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                notBefore: now,
                claims: settingsDto.Identity.Claims,
                expires: now.Add(TimeSpan.FromDays(settingsDto.LifeTime)),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
