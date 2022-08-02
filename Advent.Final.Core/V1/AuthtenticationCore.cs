using Advent.Final.Contracts.Repository;
using Advent.Final.Core.Handlers;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using Advent.Final.Entities.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class AuthtenticationCore
    {
        private readonly UserCore _userCore;
        private readonly IConfiguration _config;

        public AuthtenticationCore(IUserRepository userContext,ILogger<User> userLogger,IMapper mapper,IConfiguration configuration)
        {
            _userCore = new(userContext, userLogger, mapper);
            _config = configuration;
        }
        public async Task<ResponseService<bool>> AddPassword(string username, string password) 
        {
            if (await _userCore.SetPassword(username, password))
            {
                return new ResponseService<bool>(false, "Password added", HttpStatusCode.OK, true);
            }
            else
            {
                return new ResponseService<bool>(true, "No password", HttpStatusCode.BadRequest, false);
            }
        }
        public async Task<ResponseService<bool>> ResetPassword(string username, string password,string newPassword) 
        {
            if (await _userCore.ChangePassword(username, password,newPassword))
            {
                return new ResponseService<bool>(false, "Password changed", HttpStatusCode.OK, true);
            }
            else
            {
                return new ResponseService<bool>(true, "No password", HttpStatusCode.BadRequest, false);
            }
        }

        public async Task<ResponseService<UserLoginDto>> AuthUser(string username,string password)
        {
            if (await _userCore.AuthUser(username, password))
            {
                var response = new UserLoginDto()
                {
                    Token = GenerarTokenJWT(username),
                    Username = username,
                    ExpireDate = DateTime.UtcNow.AddDays(1)
                };
                return new ResponseService<UserLoginDto>(false, "Login successful", HttpStatusCode.OK, response);
            }
            else
            {
                return new ResponseService<UserLoginDto>(true, "Login unsuccessful", HttpStatusCode.Forbidden, new());
            }
        }

        private string GenerarTokenJWT(string username)
        {
            // Create header
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // Create claims
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, username),
            };

            // Create payload
            var _Payload = new JwtPayload(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Expired in 24 hours.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // Create a Token
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
