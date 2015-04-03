(function () {

    angular.module("includeReplace", []).directive("includeReplaceDirective",
        function () {
            return {
                restrict: 'A',
                link: function (scope, el, attrs) {
                    el.replaceWith(el.children());
                }
            };
        });
})();