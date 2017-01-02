﻿(function () {
    'use strict';

    var app = angular.module('app', ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/main", {
                templateUrl: "main.html",
                controller: "MainController"
            })
            .when("/about", {
                templateUrl: "about.html",
                controller: "AboutController"
            })
            .otherwise(
            { redirectTo: "/main" }
            );
    });
})();