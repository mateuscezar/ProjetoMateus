(function () {
    "use strict";

    angular.module('app.controllers').controller('CategoriaEditController', CategoriaEditController);
    CategoriaEditController.$inject = ['$scope', '$state', 'CategoriaService', 'AlertService'];

    function CategoriaEditController($scope, $state, CategoriaService, AlertService) {

        $scope.Dto = {};

        $scope.update = function () {
            CategoriaService.Update($scope.Dto, function (data) {
                $state.go('categoria');
                AlertService.addSuccess("Categoria alterada com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };

        function load() {
            CategoriaService.GetById($state.params.id, function (data) {
                $scope.Dto = data
            }, function (error) { AlertService.addError(error.message); });
        }
        load();
    }
})();