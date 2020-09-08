angular.module('app').controller('BookingController',
    function ($rootScope, $scope, $filter, $state) {
        $scope.state = 0;

        $scope.searchInfo = undefined;
        $scope.outboundFlights = [];
        $scope.returnFlights = [];
        $scope.outboundFlight = undefined;
        $scope.returnFlight = undefined;
        $scope.passengers = [];
        $scope.bookingDetails = undefined;
        $scope.cardInfo = undefined;

        $scope.goTo = goTo;

        function goTo(state)
        {
            $scope.state = state;
        }
    });
