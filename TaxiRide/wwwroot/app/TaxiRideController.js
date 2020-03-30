'use strict'

taxiRideApp.controller('TaxiRideController',
    function ($scope, $http) {
        $scope.event= {
            sendRideInfo: sendRideInfo,
            getRideInfo: getRideInfo,
            cost: "",
            numOfMinutesAboveSixMPH: "",
            numOfMilesBelowSixMPH: "",
            Date: "",
            StartTime: "",
            ErrorMessage: ""

        };

        function getRideInfo() {
            return $http({
                method: 'GET',
                url: 'api/Taxi'
            })
        }

        function sendRideInfo(isValid) {
            if (isValid) {
                var jsonBody = {
                    NumOfMinutesAboveSixMPH: $scope.event.numOfMinutesAboveSixMPH,
                    NumOfMilesBelowSixMPH: $scope.event.numOfMilesBelowSixMPH,
                    DateOfRide: $scope.event.Date,
                    TimeOfStart: $scope.event.StartTime
                }
                return $http({
                    method: 'POST',
                    url: 'api/Taxi',
                    data: jsonBody
                }).then(function () {
                    getRideInfo().then(function (response) {
                        $scope.event.cost = response.data;
                    });
                });
            }
        }
    }
);