(function () {
    "use strict";

    angular.module('app.controllers').controller('CategoriaNewController', CategoriaNewController);
    CategoriaNewController.$inject = ['$scope', '$state', 'CategoriaService', 'AlertService'];

    function CategoriaNewController($scope, $state, CategoriaService, AlertService) {

        $scope.Dto = {};

        $scope.save = function () {
            CategoriaService.Save($scope.Dto, function (data) {
                $state.go('categoria');
                AlertService.addSuccess("Categoria inserido com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };
    }
})();