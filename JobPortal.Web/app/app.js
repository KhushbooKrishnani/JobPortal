var app = angular.module('Job_Portal', ['ngRoute','selectize']);


app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "Home/home.html"
    });

    $routeProvider.when("/jobSearch", {
        controller: "jobSearchController",
        templateUrl: "JobSearch/jobSearch.html"
    });

    $routeProvider.otherwise({
        redirectTo: "/home"
            });

//app.config(function ($routeProvider) {

//    $routeProvider.when("/header", {
//        controller: "headerController",
//        templateUrl: "Header/header.html"
//    });
//    $routeProvider.otherwise({
//        redirectTo: "/header"
//    });
 });