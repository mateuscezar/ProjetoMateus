(function () {
    "use strict";

    angular.module('app.controllers').controller('ProdutoListaController', ProdutoListaController);
    ProdutoListaController.$inject = ['$scope', '$state', 'ProdutoService', 'AlertService'];

    function ProdutoListaController($scope, $state, ProdutoService, AlertService) {
       
        ProdutoService.GetAll(function (data) {
            $scope.Lista = data;
        }, function (error) { AlertService.addError(error.message); });

        $scope.update = function (id) {
            $state.go('produtoedit', { id: id });
        };

        $scope.new = function () {
            $state.go('produtonew');
        };

        $scope.remove = function (id) {
            ProdutoService.Delete(id, function (data) {
                ProdutoService.GetAll(function (data) {
                    $scope.Lista = data;
                    AlertService.addSuccess("Produto excluido com sucesso.");
                });
            }, function (error) { AlertService.addError(error.message); });
        };

    }
})();