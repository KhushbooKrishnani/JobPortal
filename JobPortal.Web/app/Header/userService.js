app.factory('userService', function ($http) {
    var userServicefactory = {};

    userServicefactory.getUsers = function () {
        
        return $http.get("http://localhost/JobPortal.Api/odata/Users");
        //$http.get("http://services.odata.org/TripPinRESTierService/People")
        //.then(function (response) {
        //    return response;
        //});

    }
    userServicefactory.createUsers = function (model) {
        return $http.post("http://localhost/JobPortal.Api/odata/Users", model);
    }

    return userServicefactory;
});