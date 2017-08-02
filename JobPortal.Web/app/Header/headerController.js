app.controller('headerController', function ($scope, $rootScope, $location, userService, skillsService, $http) {
    $rootScope.userDetails = {};
    $scope.loginData = {};
    $scope.registerData = {};
    $scope.users = [];
    $scope.loginFail = false;
    var flag = true;
    $scope.skills = [];
    $scope.role = false;
    $scope.showRegisterPanel = function () {
        $('#loginModal').modal('hide');
        $('#registerModal').modal('show');
    }
    $scope.showLoginPanel = function () {
        $('#registerModal').modal('hide');
        $('#loginModal').modal('show');
    }

    $scope.login = function () {
        userService.getUsers().then(function (results) {
            $scope.users = results.data.value;

            angular.forEach($scope.users, function (value, key) {
                if (value.Email == $scope.loginData.Email && value.Password == $scope.loginData.Password) {
                    $rootScope.userDetails = value;
                    $location.path('/home');

                    flag = false;
                    //alert("Login Successful");
                    $('#loginModal').modal('hide');

                    
                }
                else if ((($scope.users.length - 1) == key) && flag == true) {
                    $scope.loginFail = true;
                    //alert("Login failed");
                }

            });

        }, function (error) {
            alert(error);
        });
    }

    $scope.register = function () {
       
        $scope.registerData.Title_Role = "Student";
         userService.createUsers($scope.registerData).then(function (results) {
             //alert("Registration Successful");
             $('#registerModal').modal('hide');

            $scope.registerData = {};
        }, function (error) {
            alert("Registration Failed");
        });
    }

    $scope.getSkill = function () {
        //var filter = "?$filter=";
        //filter = filter + "Id ne " + $rootScope.userDetails.Id;
        skillsService.getSkills().then(function (results) {
            $scope.skills = $.map(results.data.value, function (item) {
                return { value: item.SkillsId, text: item.Name };
            });

        },
    function (error) {
        alert(error);
    });
    }


    $scope.getSkill();


});