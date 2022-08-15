using Advent.Final.Contracts.Repository;
using Advent.Final.DataAccess.Context;
using Advent.Final.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Repositories.ImplementRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository()
        {
            _context = new();
        }
        public async Task<Tuple<User, bool>> AddAsync(User entity)
        {
            try
            {
                var result = _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                var result = await _context.Users.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetByFilterAsync(Expression<Func<User, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Users.Where<User>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tuple<User, bool>> UpdateAsync(User entity)
        {
            try
            {
                var result = _context.Users.Update(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
