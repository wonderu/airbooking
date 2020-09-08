angular.module('app.public')
    .service('flightService', ['$http', function ($http) {

        var flightServiceUrl = 'api/flightschedule';

        return {
            get: function (departureAirport, arrivalAirport, departureDate, arrivalDate, adultCount, childCount, infantCount) {
                return $http.post(flightServiceUrl, {
                            fromAirportCode: departureAirport,
                            toAirportCode: arrivalAirport,
                            startDateTime: departureDate,
                            endDateTime: arrivalDate,
                            adultCount: adultCount,
                            infantCount: childCount,
                            childrenCount: infantCount
                        });
            }
        };
    }]);