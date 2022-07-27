using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Contracts.Generics
{
    public interface IGenericActionDbAddUpdate<T> where T : class
    {
        Task<Tuple<T, bool>> AddAsync(T entity);
        Task<Tuple<T, bool>> UpdateAsync(T entity);
    }
}
