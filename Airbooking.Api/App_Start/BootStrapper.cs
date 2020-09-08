using System.Web.Http;
using Airbooking.Api.Mappings;
using Airbooking.Api.Providers;
using Airbooking.Data.Infrastructure;
using Airbooking.Data.Repositories;
using Airbooking.Service;
using Airbooking.Utils.Logging;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Airbooking.Api
{
    /// <summary>
    /// Boot Strapper
    /// </summary>
    public class BootStrapper
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void Run()
        {
            SetDiContainer();
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// Sets the di container.
        /// </summary>
        private static void SetDiContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDbFactory, DbFactory>(Lifestyle.Scoped);
            container.Register<IPriceCalculatorProvider, PriceCalculatorProvider>(Lifestyle.Scoped);
            
            container.Register<IFlightScheduleService, FlightScheduleService>(Lifestyle.Scoped);
            container.Register<IFlightScheduleRepository, FlightScheduleRepository>(Lifestyle.Scoped);

            container.Register<IAirportService, AirportService>(Lifestyle.Scoped);
            container.Register<IAirportRepository, AirportRepository>(Lifestyle.Scoped);

            container.Register<IBookingService, BookingService>(Lifestyle.Scoped);
            container.Register<IBookingRepository, BookingRepository>(Lifestyle.Scoped);

            container.Register<IPaymentProvider, PaymentProvider>(Lifestyle.Scoped);

            container.Register<IEmailService, Providers.EmailService>(Lifestyle.Scoped);

            container.Register<IHttpAuthorizationProvider, HttpAuthorizationProvider>(Lifestyle.Scoped);

            //container.Register<ILoggingService>(LoggingService.GetLoggingService, Lifestyle.Singleton);
            container.RegisterConditional(typeof(ILoggingService),
                    c => typeof(LoggingService<>).MakeGenericType(c.Consumer.ImplementationType),
                    Lifestyle.Singleton,
                    c => true);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            
        }
    }
}
