app.factory('skillsService', function ($http) {
    var skillsServicefactory = {};
    skillsServicefactory.getSkills = function () {
       
        return $http.get("http://localhost/JobPortal.Api/odata/Skills");

    }
    //skillsServicefactory.createSkills = function (model) {
    //    return $http.post("http://localhost/JobPortal.Api/odata/Skills", model);

    //}
    return skillsServicefactory;
});