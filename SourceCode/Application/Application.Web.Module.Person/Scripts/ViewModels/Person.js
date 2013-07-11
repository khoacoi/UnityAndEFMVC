function PersonViewModel(options) {
    var item = options;
    var app = angular.module('app', []);

    var url = 'api/person/';

    app.factory('personFactory', function ($http) {
        return {
            getPeople: function () {
                return $http.get(url);
            },
            addPerson: function (person) {
                return $http.post(url, person);
            },
            deletePerson: function (person) {
                return $http.delete(url + person.Id);
            },
            updatePerson: function (person) {
                return $http.put(url + person.Id, person);
            }
        };
    });

    app.factory('notificationFactory', function () {

        return {
            success: function () {
                toastr.success("Success");
            },
            error: function (text) {
                toastr.error(text, "Error!");
            }
        };
    });

    app.controller('PersonIndexCtrl', function ($scope, personFactory, notificationFactory) {
        $scope.Name = 'Name';
        $scope.people = [];
        $scope.addMode = false;

        $scope.toggleAddMode = function () {
            $scope.addMode = !$scope.addMode;
        };

        $scope.toggleEditMode = function (person) {
            person.editMode = !person.editMode;
        };

        var getPeopleSuccessCallback = function (data, status) {
            $scope.people = data;
        };

        var successCallback = function (data, status, headers, config) {
            notificationFactory.success();

            return personFactory.getPeople().success(getPeopleSuccessCallback).error(errorCallback);
        };

        var successPostCallback = function (data, status, headers, config) {
            successCallback(data, status, headers, config).success(function () {
                $scope.toggleAddMode();
                $scope.person = {};
            });
        };

        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };


        //personFactory.getPeople().success(getPeopleSuccessCallback).error(errorCallback);

        $scope.addPerson = function () {
            personFactory.addPerson($scope.person).success(successPostCallback).error(errorCallback);
        };

        $scope.deletePerson = function (person) {
            personFactory.deletePerson(person).success(successCallback).error(errorCallback);
        };

        $scope.updatePerson = function (person) {
            personFactory.updatePerson(person).success(successCallback).error(errorCallback);
        };
    });
}


    
