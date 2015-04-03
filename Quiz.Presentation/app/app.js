(function () {
    var app = angular.module('app', ['ngRoute', 'ngAnimate', 'restangular', 'LocalStorageModule', 'base64', 'toaster',
        'ui.bootstrap', 'ngIdle', 'ngCookies', 'ngSanitize', 'chieffancypants.loadingBar', 'slick', 'includeReplace', 'myRepeat']);

    var getView = function (baseName) {
        var view = null;
        if (baseName == 'dashboard') {
            view = 'app/partials/dashboard.html';
        }

        return view;
    };

    var getController = function (baseName) {
        var controller = null;
        if (baseName == 'dashboard') {
            controller = 'app/controllers/dashboardCtrl.js';
        }

        return controller;
    };

    var getData = [
        '$q', 'dataService', function($q, dataService) {
            var promises = [];
            promises.push(dataService.getQuestions());

            return $q.all(promises);
        }
    ];

    app.config([
        '$routeProvider', 'routeResolverProvider', '$controllerProvider', '$compileProvider',
        '$filterProvider', '$provide', 'RestangularProvider', '$idleProvider', 'cfpLoadingBarProvider',
        function ($routeProvider, routeResolverProvider, $controllerProvider, $compileProvider, $filterProvider, $provide,
            RestangularProvider, $idleProvider, cfpLoadingBarProvider) {

            app.register =
            {
                controller: $controllerProvider.register,
                directive: $compileProvider.directive,
                filter: $filterProvider.register,
                factory: $provide.factory,
                service: $provide.service
            };

            cfpLoadingBarProvider.includeSpinner = false;

            $idleProvider.idleDuration(180);
            $idleProvider.warningDuration(30);

            var route = routeResolverProvider.route(getView, getController);

            RestangularProvider.setBaseUrl(GLOBALCONFIGURATION.WebApiUrl);

            $routeProvider.when('/dashboard', route.resolve('dashboard', 'dashboard', false, getData));

            $routeProvider.otherwise({ redirectTo: '/dashboard' });
        }
    ]).run([
            '$route', '$templateCache', function ($route, $templateCache) {
                $route.reload();
            }
    ]);;

    app.factory('$exceptionHandler', function ($injector) {
        return function (exception, cause) {
            //var logger = $injector.get('logService');
            //var rootScope = $injector.get('$rootScope');
            //rootScope.$broadcast(memXGGlobalConfigs.memXGNotification, 'error', memXGGlobalConfigs.Message.GENERIC_HEADER, memXGGlobalConfigs.Message.GENERIC_FAILURE, 5000);
            //logger.error(exception.message, exception.stack);

            //exception.message += ' (caused by "' + cause + '")';
            //throw exception;
        };
    });

    return app;
})();