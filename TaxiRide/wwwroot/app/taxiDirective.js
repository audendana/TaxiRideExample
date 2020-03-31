taxiRideApp.directive('taxiRideForm', function () {
    return {
        restrict: 'E',
        scope: {
            event: '=',
            getRideInfo: '=',
            sendRideInfo: '=',
            setJsonData: '='
        },
        templateUrl: 'taxiRideForm.html',
    };
});