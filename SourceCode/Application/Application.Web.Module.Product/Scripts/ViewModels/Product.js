function ProductViewModel(options) {
    var viewModel = options.viewModel;

    var app = angular.module('ProductApp', []);
    var url = '/api/productManager/';

    app.factory('productFactory', function ($http) {
        return {
            getProduct: function () {
                return $http.get(url);
            },
            getProductByID: function (id) {
                return $http.get(url + id);
            },
            addProduct: function (product) {
                return $http.post(url, product);
            },
            updateProduct: function (product) {
                return $http.put(url + product.ID, product);
            }
        };
    });

    app.controller('UpdateProductCtrl', function ($scope, productFactory) {

        $scope.saveCategory = function (categoryViewModel) {
            if (categoryViewModel.Id) {
                categoryFactory.updateCategory(categoryViewModel).success(function (data, status, headers, config) {
                    window.location.href = '/Product/Manage';
                });
            }
            else {
                categoryFactory.addCategory(categoryViewModel).success(function (data, status, headers, config) {
                    window.location.href = '/Product/Manage';
                });;
            }
        }

        if (viewModel.Id) {
            categoryFactory.getCategoryByID(viewModel.Id).success(function (data, status, headers, config)
            { $scope.category = data });
        }
    });
}