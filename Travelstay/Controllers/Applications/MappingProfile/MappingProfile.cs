using AutoMapper;
using Travelstay.Controllers.Applications.DTO;
using Travelstay.Domain.Entity;

namespace Travelstay.Controllers.Applications.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TourBooking, TourBookingDto>().ReverseMap();
            CreateMap<RoomReservation, RoomReservationDto>().ReverseMap();
        }
        
    }
}
