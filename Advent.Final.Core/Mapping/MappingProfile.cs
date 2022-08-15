using Advent.Final.Entities.DTOs;
using Advent.Final.Entities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            ////Booking
            //CreateMap<BookingCreateDto, Booking>();
            //CreateMap<Booking, BookingCreateDto>();

            //Booking detail
            CreateMap<BookingDetailDto, BookingDetail>();
            CreateMap<BookingDetail, BookingDetailDto>();
        }
    }
}
