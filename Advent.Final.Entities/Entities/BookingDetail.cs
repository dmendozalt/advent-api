using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Entities.Entities
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ContainerId { get; set; }
        public int Fee { get; set; }
    }
}
