angular.module('app.public').directive('paymentResult',
    function () {
        function link(scope, element, attributes) {

        }

        return {
            scope:
            {
                back: '&'
            },
            restrict: 'E',
            link: link,
            templateUrl: 'scripts/modules/public/templates/payment-result.html'
        }
    });