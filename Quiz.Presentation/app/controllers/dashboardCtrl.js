(function () {


    var app = angular.module("app");

    var dashboardCtrl = function ($scope, data) {
        $scope.questions = data[0];

        $scope.submitAnswers = function() {

        };
    };

    app.controller('dashboardCtrl', ['$scope', 'data', dashboardCtrl]);
}
)();