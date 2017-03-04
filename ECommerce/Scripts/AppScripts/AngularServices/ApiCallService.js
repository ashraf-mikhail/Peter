app.service('ApiCall', ['$http', function ($http) {
    this.GetApiCall = function(controllerName) {
        return $http.get('http://onlineshoptest.com/api/' + controllerName);
    };

}]);

