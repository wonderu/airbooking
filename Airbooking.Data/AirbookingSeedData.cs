using System;
using Airbooking.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Airbooking.Data
{
    /// <summary>
    /// Airbooking seed data class
    /// </summary>
    public class AirbookingSeedData : DropCreateDatabaseIfModelChanges<AirbookingEntities>
    {
        /// <summary>
        /// A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(AirbookingEntities context)
        {
            var airports = GetAirports();
            Random rnd = new Random();
            var flights = new List<Flight>();
            
            foreach (var airport in airports)
            {
                foreach (var airport2 in airports)
                {
                    if (airport != airport2)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            var gate = rnd.Next(20) + 1;
                            var gate2 = rnd.Next(20) + 1;
                            var hours = rnd.Next(19) + 1;
                            var hours2 = rnd.Next(3);
                            var minutes = rnd.Next(50);
                            var minutes2 = rnd.Next(50);
                            var time = new TimeSpan(hours, minutes, 0);
                            var flight = new Flight
                            {
                                DepartureInfo = new FlightInfo { Airport = airport, Gate = gate.ToString(), Time = time },
                                ArrivalInfo = new FlightInfo { Airport = airport2, Gate = gate2.ToString(), Time = time.Add(new TimeSpan(hours2, minutes2, 0)) },
                                Code = "SU-" + rnd.Next(999)
                            };
                            flights.Add(flight);
                        }
                    }
                }
            }

            var airplane = GetAirplane();
            var date = DateTime.Now.Date;
            for (int i = 0; i < 10; i++)
            {
                foreach (var flight in flights)
                {
                    context.FlightSchedules.Add(new FlightSchedule { Airplane = airplane, DepartureDate = date, Flight = flight});
                }
                date = date.AddDays(1);
                context.Commit();
            }
                
            //airports.ForEach(a => context.Airports.Add(a));

            context.Commit();
        }

        private static Airplane GetAirplane()
        {
            var airplane = new Airplane
            {
                Model = "Airbus A321",
                SeatingCapacity = 186
            };

            var seats = new List<Seat>();
            for (int i = 1; i <= 31; i++)
            {
                for (char j = 'A'; j <= 'F'; j++)
                {
                    seats.Add(new Seat { SeatingNumber  = i.ToString() + j, Airplane = airplane, X = 0, Y = 0});
                }
            }

            airplane.Seats = seats;

            return airplane;
        }

        private static List<Airport> GetAirports()
        {
            return new List<Airport>
            {
                new Airport { Name = "Agnew", City = "Agnew", Code = "AGW"},
                new Airport { Name = "Alice Springs Railway", City = "Alice Springs", Code = "XHW"},
                new Airport { Name = "Bremen", City = "Bremen", Code = "BRE"},
                new Airport { Name = "Cleve", City = "Cleve", Code = "CVC"},
                new Airport { Name = "Darwin", City = "Darwin", Code = "DRW"},
                new Airport { Name = "Blue Danube", City = "Linz", Code = "LNZ"},
                new Airport { Name = "Franz Josef Strauss", City = "Munich", Code = "MUC"},
                new Airport { Name = "Portland", City = "Portland", Code = "PTJ"},
                new Airport { Name = "Cote d'Azur International Airport", City = "Nice", Code = "NCE"}
            };
        }
    }
}
