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
    public class BookingRepository : IBookingRepository
    {
        private readonly MySqlContext _context;

        public BookingRepository()
        {
            _context = new();
        }

        public async Task<Tuple<Booking, bool>> AddAsync(Booking entity)
        {
            try
            {
                var result = _context.Bookings.Add(entity);
                await _context.SaveChangesAsync();
                return Tuple.Create(result.Entity, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            try
            {
                var result = await _context.Bookings.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Booking>> GetByFilterAsync(Expression<Func<Booking, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.Bookings.Where<Booking>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Bookings.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Tuple<Booking, bool>> UpdateAsync(Booking entity)
        {
            try
            {
                var result = _context.Bookings.Update(entity);
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
