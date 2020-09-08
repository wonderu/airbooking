angular.module('app.public')
    .service('airportService', ['$http', function ($http) {
        var airportServiceUrl = 'api/airport';

        return {
            get: function (code) {
                return $http.get(airportServiceUrl + '?code=' + code);
            },
            list: function () {
                return $http.get(airportServiceUrl);
            }
        };
    }]);