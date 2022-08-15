using Advent.Final.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Entities.DTOs
{
    public class BookingShowDto: Booking
    {
        public BookingDetail[] Details { get; set; }
    }
}
