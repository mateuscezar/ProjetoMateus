(function () {
    "use strict";

    angular.module('app.controllers').controller('CategoriaListaController', CategoriaListaController);
    CategoriaListaController.$inject = ['$scope', '$state', 'CategoriaService', 'AlertService'];

    function CategoriaListaController($scope, $state, CategoriaService, AlertService) {
       
        CategoriaService.GetAll(function (data) {
            $scope.Lista = data;
        }, function (error) { AlertService.addError(error.message); });

        $scope.update = function (id) {
            alert('update: ' + id);
        };

        $scope.new = function (id) {
            $state.go('categorianew');
        };

        $scope.remove = function (id) {
            CategoriaService.Delete(id, function (data) {
                CategoriaService.GetAll(function (data) {
                    $scope.Lista = data;
                    AlertService.addSuccess("Categoria excluida com sucesso.");
                });
            }, function (error) { AlertService.addError(error.message); });
        };

    }
})();