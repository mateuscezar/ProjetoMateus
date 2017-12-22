(function () {
    "use strict";

    angular.module('app.controllers').controller('ProdutoEditController', ProdutoEditController);
    ProdutoEditController.$inject = ['$scope', '$state', 'ProdutoService', 'AlertService'];

    function ProdutoEditController($scope, $state, ProdutoService, AlertService) {

        $scope.Dto = {};

        $scope.update = function () {
            ProdutoService.Update($scope.Dto, function (data) {
                $state.go('produto');
                AlertService.addSuccess("Produto alterado com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };

        function load() {
            ProdutoService.GetById($state.params.id, function (data) {
                $scope.Dto = data
            }, function (error) { AlertService.addError(error.message); });
        }
        load();
    }
})();