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
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly MySqlContext _context;
        public PaymentMethodRepository()
        {
            _context = new();
        }
        public Task<Tuple<PaymentMethod, bool>> AddAsync(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentMethod>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PaymentMethod>> GetByFilterAsync(Expression<Func<PaymentMethod, bool>> expressionFilter = null)
        {
            try
            {
                return await _context.PaymentMethods.Where<PaymentMethod>(expressionFilter).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaymentMethod> GetByIdAsync(int id)
        {
            try
            {
                return await _context.PaymentMethods.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Tuple<PaymentMethod, bool>> UpdateAsync(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }
    }
}
