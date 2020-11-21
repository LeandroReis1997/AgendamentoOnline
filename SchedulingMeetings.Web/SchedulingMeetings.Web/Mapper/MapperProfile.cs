using AutoMapper;
using SchedulingMeetings.Web.DTO.Room;
using SchedulingMeetings.Web.DTO.Scheduling;
using SchedulingMeetings.Web.ViewModels;

namespace SchedulingMeetings.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RoomViewModel, RoomListDTO>().ReverseMap();
            CreateMap<RoomViewModel, RoomDTO>().ReverseMap();

            CreateMap<SchedulingViewModel, SchedulingListDTO>();
            CreateMap<SchedulingViewModel, SchedulingDTO>().ReverseMap();
        }
    }
}
