'use strict'

taxiRideApp.controller('TaxiRideController',
    function ($scope, $http) {
        $scope.event = {
            cost: "",
            numOfMinutesAboveSixMPH: "",
            numOfMilesBelowSixMPH: "",
            Date: "",
            StartTime: "",
            ErrorMessage: ""

        };

        $scope.getRideInfo = function () {
            return $http({
                method: 'GET',
                url: 'api/Taxi'
            });
        };

        $scope.sendRideInfo = function (jsonBody) {
            return $http({
                method: 'POST',
                url: 'api/Taxi',
                data: jsonBody
            }).then(function () {
                $scope.getRideInfo().then(function (response) {
                    $scope.event.cost = response.data;
                });
            });
        };

        $scope.setJsonData = function (isValid) {
            if (isValid) {
                var jsonBody = {
                    NumOfMinutesAboveSixMPH: $scope.event.numOfMinutesAboveSixMPH,
                    NumOfMilesBelowSixMPH: $scope.event.numOfMilesBelowSixMPH,
                    DateOfRide: $scope.event.Date,
                    TimeOfStart: $scope.event.StartTime
                }
                $scope.sendRideInfo(jsonBody);
            }
        };
    }
);

