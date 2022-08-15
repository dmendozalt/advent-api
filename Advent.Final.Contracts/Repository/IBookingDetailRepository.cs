using Advent.Final.Contracts.Generics;
using Advent.Final.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Contracts.Repository
{
    public interface IBookingDetailRepository: IGenericActionDbAddUpdate<BookingDetail>, IGenericActionDbQuery<BookingDetail>
    {
    }
}
