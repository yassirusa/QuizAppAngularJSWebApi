(function () {

    var app = angular.module('app');

    var routeResolver = function () {

        this.$get = function () {
            return this;
        };

        this.route = function (getView, getController) {

            var resolve = function (baseName, baseNameOverride, isAuthorized, getData) {
                var routeDef = {};
                routeDef.templateUrl = getView(baseName);
                if (baseNameOverride !== undefined) {
                    routeDef.controller = baseNameOverride + 'Ctrl';
                } else {
                    routeDef.controller = baseName + 'Ctrl';
                }
                routeDef.resolve = {
                    load: ['$q', '$rootScope', '$location', '$timeout', '$cookieStore', 'cfpLoadingBar',
                        function ($q, $rootScope, $location, $timeout, $cookieStore, cfpLoadingBar) {

                            cfpLoadingBar.start();
                            $rootScope.$on('cfpLoadingBar:started', function () {
                                $('.validation-form').bootstrapValidator('disableSubmitButtons', true);
                            });
                            var dependencies = [getController(baseName)];
                            return resolveDependencies($q, $rootScope, $location, $timeout, $cookieStore, dependencies, isAuthorized, cfpLoadingBar);
                        }],
                    data: (getData) ||
                    ['$q', function ($q) {
                        return $q.defer().resolve();
                    }]
                };
                return routeDef;
            },

            resolveDependencies = function ($q, $rootScope, $location, $timeout, $cookieStore, dependencies, isAuthorized, cfpLoadingBar) {
                var defer = $q.defer();
                require(dependencies, function () {


                    defer.resolve();
                    $rootScope.$apply();

                    $timeout(function () {
                        cfpLoadingBar.complete();
                    }, 0);
                    $rootScope.$on('cfpLoadingBar:completed', function () {
                        var bootstrapValidator = $('.validation-form').data('bootstrapValidator');
                        if (bootstrapValidator != undefined) {
                            $('.validation-form').bootstrapValidator('disableSubmitButtons', false);
                        }
                    });
                });

                return defer.promise;
            };

            return {
                resolve: resolve
            };
        };

    };

    app.provider('routeResolver', routeResolver);
})();


