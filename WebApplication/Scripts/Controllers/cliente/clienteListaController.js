(function () {
    "use strict";

    angular.module('app.controllers').controller('ClienteListaController', ClienteListaController);
    ClienteListaController.$inject = ['$scope', '$state', 'ClienteService', 'AlertService'];

    function ClienteListaController($scope, $state, ClienteService, AlertService) {
       
        ClienteService.GetAll(function (data) {
            $scope.Lista = data;
        }, function (error) { AlertService.addError(error.message); });

        $scope.update = function (id) {
            $state.go('clienteedit', { id: id });
        };

        $scope.new = function (id) {
            $state.go('clientenew');
        };

        $scope.remove = function (id) {
            ClienteService.Delete(id, function (data) {
                ClienteService.GetAll(function (data) {
                    $scope.Lista = data;
                    AlertService.addSuccess("Cliente excluido com sucesso.");
                });
            }, function (error) { AlertService.addError(error.message);});
        };
    }
})();