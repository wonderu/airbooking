angular.module('app.public')
    .service('bookingService', ['$http', function ($http) {
        var bookingServiceUrl = 'api/booking';

        return {
            book: function (passengers, cardInfo, totalPrice, outboundFlight, returnFlight)
            {
                return $http.post(bookingServiceUrl, {
                    OutboundFlightScheduleId: outboundFlight.flightScheduleId,
                    ReturnFlightScheduleId: returnFlight != null ? returnFlight.flightScheduleId : null,
                    Passengers: passengers,
                    CreditCard: cardInfo,
                    Price: totalPrice
                });
            }
        };
    }]);