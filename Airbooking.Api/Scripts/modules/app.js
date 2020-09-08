angular.module('app', [
        'ui.router',
        'ui.bootstrap',
        'app.public'
    ])
    .config(function ($provide, $httpProvider, $stateProvider) {
        $provide.factory('ErrorHttpInterceptor', function($q) {
            function notifyError(rejection)
            {
            }

            return {
                // On request failure
                requestError: function(rejection)
                {
                    // show notification
                    notifyError(rejection);

                    // Return the promise rejection.
                    return $q.reject(rejection);
                },

                // On response failure
                responseError: function(rejection)
                {
                    // show notification
                    notifyError(rejection);
                    // Return the promise rejection.
                    return $q.reject(rejection);
                }
            };
        });

        // Add the interceptor to the $httpProvider.
        $httpProvider.interceptors.push('ErrorHttpInterceptor');
    });


