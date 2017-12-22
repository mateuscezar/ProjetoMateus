(function () {
    "use strict";

    angular.module('app.controllers').controller('ProdutoNewController', ProdutoNewController);
    ProdutoNewController.$inject = ['$scope', '$state', 'ProdutoService', 'AlertService'];

    function ProdutoNewController($scope, $state, ProdutoService, AlertService) {

        $scope.Dto = {};

        $scope.save = function () {
            ProdutoService.Save($scope.Dto, function (data) {
                $state.go('produto');
                AlertService.addSuccess("Produto inserido com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };
    }
})();