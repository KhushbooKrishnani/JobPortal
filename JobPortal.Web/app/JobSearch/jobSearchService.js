app.factory('jobSearchService', function ($http) {
    var jobSearchServicefactory = {};
    jobSearchServicefactory.getLocations = function () {
        
        return $http.get("http://localhost/JobPortal.Api/odata/Locations");

    }
    jobSearchServicefactory.getCompanies = function () {

        return $http.get("http://localhost/JobPortal.Api/odata/Companies");

    }
    jobSearchServicefactory.getSkills = function () {

        return $http.get("http://localhost/JobPortal.Api/odata/Skills");

    }
    jobSearchServicefactory.getJobs = function () {

        return $http.get("http://localhost/JobPortal.Api/odata/Jobs");

    }
    //skillsServicefactory.createSkills = function (model) {
    //    return $http.post("http://localhost/JobPortal.Api/odata/Companies", model);

    //}
    return jobSearchServicefactory;
});