var app = angular.module('CategoryApp', []);
var url = '/api/categoryManager/';

app.factory('categoryFactory', function ($http) {
    return {
        getCategories: function () {
            return $http.get(url);
        },
        addCategory: function (category) {
            return $http.post(url, category);
        },
        deleteCategory: function (category) {
            return $http.delete(url + category.CategoryID);
        },
        updateCategory: function (category) {
            return $http.put(url + category.CategoryID, category);
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

app.controller('ManageCategoryCtrl', function ($scope, categoryFactory, notificationFactory) {
    $scope.categories = [];

    $scope.deleteCategory = function (category) {
        categoryFactory.deleteCategory(category).success(function (data, status, header, config) {
            $scope.categories.splice($scope.categories.indexOf(category), 1);
        });
    };
    $scope.editCategory = function (category) {
        location.href = '/Category/Update/' + category.CategoryID;
    };
    $scope.createCategory = function () {
        location.href = '/Category/Update';
    }

    var getCategoriesSuccessCallBack = function (data, status, headers, config) {
        $scope.categories = data;
    };

    var errorCallBack = function (data, status, headers, config) {
        notificationFactory.error(data.ExceptionMessage);
    };

    categoryFactory.getCategories().success(getCategoriesSuccessCallBack).error(errorCallBack);
});