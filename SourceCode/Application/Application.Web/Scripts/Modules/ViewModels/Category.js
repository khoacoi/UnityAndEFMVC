function CategoryViewModel(options) {
    var viewModel = options.viewModel;

    var app = angular.module('CategoryApp', []);
    var url = '/api/categoryManager/';

    app.factory('categoryFactory', function ($http) {
        return {
            getCategory: function () {
                return $http.get(url);
            },
            getCategoryByID: function(id){
                return $http.get(url + id);
            },
            addCategory: function (category) {
                return $http.post(url, category);
            },
            ////deletePerson: function (person) {
            ////    return $http.delete(url + person.Id);
            ////},
            //deletePerson: function (person) {
            //    return $http.post('person/DeletePerson', person);
            //},
            updateCategory: function (category) {
                return $http.put(url + category.ID, category);
            }
        };
    });


    app.controller('UpdateCategoryCtrl', function ($scope, categoryFactory) {
        //$scope.category = {};
        
        $scope.saveCategory = function (categoryViewModel) {
            if (categoryViewModel.Id) {
                categoryFactory.updateCategory(categoryViewModel).success(function (data, status, headers, config) {
                    window.location.href = '/Category/Manage';
                });
            }
            else {
                categoryFactory.addCategory(categoryViewModel).success(function (data, status, headers, config) {
                    window.location.href = '/Category/Manage';
                });;
            }
        }

        if(viewModel.Id)
        {
            categoryFactory.getCategoryByID(viewModel.Id).success(function (data, status, headers, config)
            { $scope.category = data });
        }
    });
}