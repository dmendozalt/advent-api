using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Contracts.Generics
{
    public interface IGenericActionDbQuery<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> expressionFilter = null);
    }
}
