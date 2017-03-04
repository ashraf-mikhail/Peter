var app = angular.module('myApp', []);

app.controller('myCtrl', function ($scope, $http, ApiCall) {

    $scope.Name = "my test from js";

    //$scope.Products = [
    //     {
    //         "Name": "Product 1",
    //         "Price": "10.00",
    //         "ImagePath": "../Images/TestPic.jpg"
    //     }, {
    //         "Name": "product 2",
    //         "Price": "10.00",
    //         "ImagePath": "../Images/TestPic.jpg"
    //     }, {
    //         "Name": "Product 3",
    //         "Price": "10.00",
    //         "ImagePath": "../Images/TestPic.jpg"
    //     }, {
    //         "Name": "product 4",
    //         "Price": "10.00",
    //         "ImagePath": "../Images/TestPic.jpg"
    //     }
    //];

    var servCall = ApiCall.GetApiCall("products");
    servCall.then(function(d) {
        $scope.Products = d.data;
    }, function(error) {
        $log.error('Oops! Something went wrong while fetching the data.');
    });

});