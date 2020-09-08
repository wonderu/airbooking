using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using AutoMapper;

namespace Airbooking.Api.Mappings
{
    /// <summary>
    /// View Model To Domain Mapping Profile Class
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Gets the name of the profile.
        /// </summary>
        /// <value>
        /// The name of the profile.
        /// </value>
        public override string ProfileName => "ViewModelToDomainMappings";

        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<BookingViewModel, Booking>();
            Mapper.CreateMap<PassengerViewModel, Passenger>();

            //.ForMember(b=>b.Tickets, map=>map.MapFrom())
            //;

            //Mapper.CreateMap<FlightScheduleViewModel, FlightSchedule>()
            //    .ForMember(g => g.DepartureDate, map => map.MapFrom(vm => vm.DepartureDate))
            //    .ForMember(g => g.Flight.DepartureInfo.Time, map => map.MapFrom(vm => vm.DepartureTime))
            //    .ForMember(g => g.Flight.DepartureInfo.Airport.City, map => map.MapFrom(vm => vm.DepartureAirportCity))
            //    .ForMember(g => g.Flight.DepartureInfo.Airport.Code, map => map.MapFrom(vm => vm.DepartureAirportCode))
            //    .ForMember(g => g.Flight.DepartureInfo.Gate, map => map.MapFrom(vm => vm.DepartureAirportGate))
            //    .ForMember(g => g.Flight.DepartureInfo.Airport.Name, map => map.MapFrom(vm => vm.DepartureAirportName))
            //    .ForMember(g => g.Airplane.Model, map => map.MapFrom(vm => vm.AirplaneModel))
            //    .ForMember(g => g.Flight.ArrivalInfo.Time, map => map.MapFrom(vm => vm.ArrivalTime))
            //    .ForMember(g => g.Flight.ArrivalInfo.Gate, map => map.MapFrom(vm => vm.ArrivalAirportGate))
            //    .ForMember(g => g.Flight.ArrivalInfo.Airport.City, map => map.MapFrom(vm => vm.ArrivalAirportCity))
            //    .ForMember(g => g.Flight.ArrivalInfo.Airport.Code, map => map.MapFrom(vm => vm.ArrivalAirportCode))
            //    .ForMember(g => g.Flight.ArrivalInfo.Airport.Name, map => map.MapFrom(vm => vm.ArrivalAirportName));
        }
    }
}