using AutoMapper;
using SchedulingMeetings.Web.DTO.Room;
using SchedulingMeetings.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingMeetings.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RoomListDTO, Room>().ReverseMap();
        }
    }
}
