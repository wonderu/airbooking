angular.module('app.public').directive('payment', ['bookingService',
    function (bookingService) {
        function link(scope)
        {
            scope.book = book;

            scope.$watch(function () {
                return scope.searchInfo;
            }, onSearchChange);


            function onSearchChange(value) {
                if (value)
                {
                    scope.passengers = new Array(scope.searchInfo.adultCount + scope.searchInfo.childCount + scope.searchInfo.infantCount);
                }
            }

            function book()
            {
                bookingService.book(scope.passengers,
                    scope.cardInfo,
                    scope.searchInfo.totalPrice,
                    scope.outboundFlight,
                    scope.returnFlight).then(function (response)
                    {
                        scope.submit();
                    });
            }
        }

        return {
            scope:
            {
                searchInfo: '=',
                cardInfo: '=',
                passengers: '=',
                outboundFlight :'=',
                returnFlight: '=',
                submit: '&',
                back: '&'
            },
            restrict: 'E',
            link: link,
            templateUrl: 'scripts/modules/public/templates/payment.html'
        }
    }]);