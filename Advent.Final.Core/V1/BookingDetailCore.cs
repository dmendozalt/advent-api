using Advent.Final.Contracts.Repository;
using Advent.Final.Core.Handlers;
using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class BookingDetailCore
    {
        private readonly IBookingDetailRepository _context;
        private readonly ErrorHandler<BookingDetail> _errorHandler;
        private readonly ILogger<BookingDetail> _logger;
        private readonly IMapper _mapper;

        public BookingDetailCore(IBookingDetailRepository context,ILogger<BookingDetail> logger,IMapper mapper)
        {
            _context=context;
            _logger=logger;
            _mapper=mapper;
            _errorHandler = new ErrorHandler<BookingDetail>(logger);
        }
        public async Task<List<BookingDetail>> AddDetails(int bookingId, List<BookingDetailDto> bookingDetails)
        {
            List<BookingDetail> details = new();
            foreach (var detail in bookingDetails)
            {
                BookingDetail newDetail = _mapper.Map<BookingDetail>(detail);
                newDetail.BookingId = bookingId;
                var result = await _context.AddAsync(newDetail);
                details.Add(result.Item1);
            }
            return details;
        }

        internal async Task<List<BookingDetail>> GetDetailsByBookingId(int id)
        {
            return await _context.GetByFilterAsync(bd => bd.BookingId.Equals(id));
        }
    }
}
