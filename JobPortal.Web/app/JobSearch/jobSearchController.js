app.controller('jobSearchController', function ($scope, jobSearchService, $rootScope) {
    $scope.locations = [];
    $scope.companies = [];
    $scope.skills = [];

    $scope.filterCompany = {};
    $scope.filterLocation = {};
    $scope.filterSkill = {};

    $scope.filterForLocation = "";
    $scope.filterForCompany = "";
    $scope.filterForSkill = "";


    var filter = "?$filter=";

    $scope.getLocation = function () {
        jobSearchService.getLocations().then(function (results) {
            $scope.locations = $.map(results.data.value, function (item) {
                return { value: item.LocId, text: item.Name };
            });

        },
    function (error) {
        alert(error);
    });
    }

    $scope.getCompany = function () {
        jobSearchService.getCompanies().then(function (results) {
            $scope.companies = $.map(results.data.value, function (item) {
                return { value: item.CompanyId, text: item.Company_Name };
            });

        },
    function (error) {
        alert(error);
    });
    }

    $scope.getSkill = function () {
        jobSearchService.getSkills().then(function (results) {
            $scope.skills = $.map(results.data.value, function (item) {
                return { value: item.SkillsId, text: item.Name };
            });

        },
    function (error) {
        alert(error);
    });
    }

    $scope.getJobs = function () {

        jobSearchService.getJobs().then(function (results) {
            $scope.jobList = results.data.value;
        },
      function (error) {
       alert(error);
      });

    }

    $scope.filterJob = function (filter) {
        if ($scope.filterForCompany == 'Company' && $scope.filterForLocation == 'Location' && $scope.filterForSkill == 'Skill') {
            $scope.jobList = $.map($scope.jobList, function (item) {
                if (item.CompId == $scope.filterCompany && item.LocId == $scope.filterLocation && item.SkillsId == $scope.filterSkill) {
                    return item;
                }
            });
            if ($scope.jobList.length == 0) {
                alert("No serach result found");
            }
        }
        else if ($scope.filterForCompany == 'Company') {
            $scope.jobList = $.map($scope.jobList, function (item) {
                if (item.CompId == $scope.filterCompany) {
                    return item;
                }
            });
            if ($scope.jobList.length == 0) {
                alert("No serach result found");
            }
        }
        else if ($scope.filterForLocation == 'Location') {
            $scope.jobList = $.map($scope.jobList, function (item) {
                if (item.LocId == $scope.filterLocation) {
                    return item;
                }
            });
            if ($scope.jobList.length == 0) {
                alert("No serach result found");
            }
        }
        else if ($scope.filterForSkill == 'Skill') {
            $scope.jobList = $.map($scope.jobList, function (item) {
                if (item.SkillsId == $scope.filterSkill) {
                    return item;
                }
            });
            if ($scope.jobList.length == 0) {
                alert("No serach result found");
            }
        }
    }

    $scope.setFilter = function (filter) {
        if (filter == 'Location') {
            $scope.filterForLocation = filter;
        }
        else if (filter == 'Company') {
            $scope.filterForCompany = filter;
        }
        else if (filter == 'Skill') {
            $scope.filterForSkill = filter;
        }

    }

    $scope.getJobs();
    $scope.getLocation();
    $scope.getCompany();
    $scope.getSkill();


});