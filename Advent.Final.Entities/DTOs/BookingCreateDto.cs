using Advent.Final.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Entities.DTOs
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public BookingDetailDto[] Details { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
