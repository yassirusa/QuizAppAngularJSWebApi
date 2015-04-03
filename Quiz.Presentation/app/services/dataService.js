(function () {
    var app = angular.module('app');

    var dataService = function ($q,  Restangular) {

        var dataServiceFactory = {};

        var _getQuestions = function() {

            var api = Restangular.all('questions');

            return api.getList()
                .then(function (response) { return response; })
                .catch(function (reason) {
                    return $q.reject("FAILURE");
                });
        }

        dataServiceFactory.getQuestions = _getQuestions;

        return dataServiceFactory;
    };

    app.factory('dataService', ['$q', 'Restangular', dataService]);

})();