angular.module('app.public').directive('searchResult',
    function () {
        function link(scope)
        {
            scope.selectOutboundFlight = selectOutboundFlight;
            scope.selectReturnFlight = selectReturnFlight;

            function selectOutboundFlight(flight)
            {
                scope.outboundFlight = flight;

                scope.searchInfo.totalPrice = scope.outboundFlight.price;
                if (scope.returnFlight)
                {
                    scope.searchInfo.totalPrice += scope.returnFlight.price;
                }

                scope.searchInfo.totalPrice = scope.searchInfo.totalPrice * (scope.searchInfo.adultCount + scope.searchInfo.childCount);
            }

            function selectReturnFlight(flight) {
                scope.returnFlight = flight;

                scope.searchInfo.totalPrice = scope.returnFlight.price;
                if (scope.outboundFlight) {
                    scope.searchInfo.totalPrice += scope.outboundFlight.price;
                }

                scope.searchInfo.totalPrice = scope.searchInfo.totalPrice * (scope.searchInfo.adultCount + scope.searchInfo.childCount);
            }
        }

        return {
            scope:
            {
                searchInfo: '=',
                outboundFlights: '=',
                returnFlights: '=',
                outboundFlight: '=',
                returnFlight: '=',
                submit: '&',
                back: '&'
            },
            restrict: 'E',
            link: link,
            templateUrl: 'scripts/modules/public/templates/search-result.html'
        }
    });