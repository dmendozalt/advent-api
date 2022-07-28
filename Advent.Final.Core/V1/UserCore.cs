using Advent.Final.Contracts.Repository;
using Advent.Final.Core.Handlers;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using Advent.Final.Entities.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class UserCore
    {
        private readonly IUserRepository _context;
        private readonly ErrorHandler<User> _errorHandler;
        private readonly ILogger<User> _logger;
        private readonly IMapper _mapper;


        public UserCore(IUserRepository context,ILogger<User> logger, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _errorHandler = new ErrorHandler<User>(logger);

        }

        public async Task<ResponseService<User>> CreateUser(UserCreateDto userCreate) {
            try
            {
                User newUser = _mapper.Map<User>(userCreate);

                var response = await _context.AddAsync(newUser);
                return new ResponseService<User>(false, response == null ? "No records found" : "Movement created", HttpStatusCode.OK, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateUser", new User());
            }
        }

        public async Task<ResponseService<User>> UpdatePassword(int userId, string password)
        {
            try
            {
                User user = await _context.GetByIdAsync(userId);
                user.Password = password;
                var response = await _context.UpdateAsync(user);
                return new ResponseService<User>(false,"Password updated",HttpStatusCode.OK, response.Item1);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdatePassword", new User());
            }
        }

        public async Task<bool> AuthUser(string username, string password)
        {
            var users = await _context.GetByFilterAsync(u => u.Username.Equals(username));
            if(users.Count == 0) { return false; }
            string passwordAttempt = EncryptCore.Encrypt_SHA256(username, password);
            return passwordAttempt == users.FirstOrDefault().Password;
        }

        public async Task<bool> SetPassword(string username, string password)
        {
            var users = await _context.GetByFilterAsync(u => u.Username.Equals(username));
            if (users.Count == 0) { return false; }
            users.FirstOrDefault().Password = EncryptCore.Encrypt_SHA256(username, password);
            return true;
        }

        public async Task<bool> ChangePassword(string username, string password, string newPassword)
        {
            var users = await _context.GetByFilterAsync(u => u.Username.Equals(username));
            if (users.Count == 0) { return false; }
            string passwordAttempt = EncryptCore.Encrypt_SHA256(username, password);
            if (passwordAttempt != users.FirstOrDefault().Password){ return false; }
            users.FirstOrDefault().Password=EncryptCore.Encrypt_SHA256(username, newPassword);
            return true;
        }
    }
}
