angular.module('app.public').directive('searchFlight', [ 'flightService', 'airportService',
    function (flightService, airportService) {
        function link(scope)
        {
            scope.departureFrom = undefined;
            scope.arrivalTo = undefined;
            scope.departureDate = new Date();
            scope.arrivalDate = new Date();
            scope.adultCount = 1;
            scope.childCount = 0;
            scope.infantCount = 0;
            scope.onewayFlight = true;

            airportService.list().then(function (response) {
                scope.airports = response.data;
            });

            scope.search = search;

            function search()
            {
                flightService.get(scope.departureFrom.code,
                    scope.arrivalTo.code,
                    scope.departureDate,
                    scope.onewayFlight ? null : scope.arrivalDate,
                    scope.adultCount,
                    scope.childCount,
                    scope.infantCount
                    ).then(function (response) {
                        scope.searchInfo = {
                            departureFrom: scope.departureFrom,
                            arrivalTo: scope.arrivalTo,
                            departureDate: scope.departureDate,
                            arrivalDate: scope.onewayFlight ? null : scope.arrivalDate,
                            adultCount: parseInt(scope.adultCount),
                            childCount: parseInt(scope.childCount),
                            infantCount: parseInt(scope.infantCount)
                        };
                        scope.outboundFlights = response.data.outboundFlights;
                        scope.returnFlights = response.data.returnFlights;
                        scope.submit();
                });
            }
        }

        return {
            scope:
            {
                searchInfo: '=',
                outboundFlights: '=',
                returnFlights: '=',
                submit: '&'
            },
            restrict: 'E',
            link: link,
            templateUrl: 'scripts/modules/public/templates/search-flight.html'
        }
    }]);