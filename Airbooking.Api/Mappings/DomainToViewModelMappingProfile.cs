using Airbooking.Api.Providers;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using AutoMapper;

namespace Airbooking.Api.Mappings
{
    /// <summary>
    /// Domain To ViewModel Mapping Profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Gets the name of the profile.
        /// </summary>
        /// <value>
        /// The name of the profile.
        /// </value>
        public override string ProfileName => "DomainToViewModelMappings";

        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<Airport, AirportViewModel>();

            Mapper.CreateMap<FlightSchedule, FlightScheduleViewModel>()
                .ForMember(g => g.FlightScheduleId, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.DepartureDate, map => map.MapFrom(vm => vm.DepartureDate))
                .ForMember(g => g.DepartureTime, map => map.MapFrom(vm => vm.Flight.DepartureInfo.Time))
                .ForMember(g => g.DepartureAirportCity, map => map.MapFrom(vm => vm.Flight.DepartureInfo.Airport.City))
                .ForMember(g => g.DepartureAirportCode, map => map.MapFrom(vm => vm.Flight.DepartureInfo.Airport.Code))
                .ForMember(g => g.DepartureAirportGate, map => map.MapFrom(vm => vm.Flight.DepartureInfo.Gate))
                .ForMember(g => g.DepartureAirportName, map => map.MapFrom(vm => vm.Flight.DepartureInfo.Airport.Name))
                .ForMember(g => g.AirplaneModel, map => map.MapFrom(vm => vm.Airplane.Model))
                .ForMember(g => g.ArrivalTime, map => map.MapFrom(vm => vm.Flight.ArrivalInfo.Time))
                .ForMember(g => g.ArrivalAirportGate, map => map.MapFrom(vm => vm.Flight.ArrivalInfo.Gate))
                .ForMember(g => g.ArrivalAirportCity, map => map.MapFrom(vm => vm.Flight.ArrivalInfo.Airport.City))
                .ForMember(g => g.ArrivalAirportCode, map => map.MapFrom(vm => vm.Flight.ArrivalInfo.Airport.Code))
                .ForMember(g => g.ArrivalAirportName, map => map.MapFrom(vm => vm.Flight.ArrivalInfo.Airport.Name))
                .ForMember(g => g.FlightCode, map => map.MapFrom(vm => vm.Flight.Code));
        }
    }
}