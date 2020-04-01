describe('Testing angularjs test suite', function() {
    beforeEach(module('TaxiRideApp'));

    describe('Testing TaxiRideController', function(){
        var scope, ctrl, httpBackend;

        beforeEach(inject(function($controller, $rootScope, $httpBackend){
            scope = $rootScope.$new();
            ctrl = $controller('TaxiRideController', {$scope:scope});
            httpBackend = $httpBackend;
        }));

        it('should get the cost of the taxi ride', function () {
            scope.event = {
                cost: "",
                numOfMinutesAboveSixMPH: "5",
                numOfMilesBelowSixMPH: "2",
                Date: "Friday (2020-12-14)",
                StartTime: "5:30pm",
                ErrorMessage: ""
            }
            httpBackend.expectGET("api/Taxi").respond("$9.75");
            httpBackend.when('POST', "api/Taxi").respond(200,{data: "$9.75"});
            scope.sendRideInfo(scope.event);
            httpBackend.flush();
            expect(scope.event.cost).toBe("$9.75");

        });

        it('should not get the cost of the taxi ride', function () {
            scope.event = {
                cost: "",
                numOfMinutesAboveSixMPH: "5",
                numOfMilesBelowSixMPH: "2",
                Date: "Friday (2020-12-14)",
                StartTime: "5:30pm",
                ErrorMessage: ""
            }
            httpBackend.expectGET("api/Taxi").respond("$9.75");
            httpBackend.when('POST', "api/Taxi").respond(200,{data: "$9.75"});
            scope.sendRideInfo(scope.event);
            httpBackend.flush();
            expect(scope.event.cost).toBe("");

        });

    })
})