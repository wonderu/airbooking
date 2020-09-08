angular.module('app.public', ['ui.router'])
    .config(function ($stateProvider) {
        $stateProvider
            .state('root', {
                url: '/',
                views: {
                    'content': {
                        templateUrl: 'Scripts/modules/public/content.html',
                        controller: 'BookingController'
                    }
                }
            });
    });


