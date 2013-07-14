var app = angular.module('CategoryApp', []);
var url = 'api/categorycontent/';

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
        categoryFactory.deleteCategory(category);
    };


    categoryFactory.getCategories().success(getCategoriesSuccessCallBack).error(errorCallBack)

    var getCategoriesSuccessCallBack = function (data, status) {
        $scope.categories = data;
    };
    var errorCallback = function (data, status, headers, config) {
        notificationFactory.error(data.ExceptionMessage);
    };
});