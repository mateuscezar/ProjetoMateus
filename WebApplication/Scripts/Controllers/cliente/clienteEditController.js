(function () {
    "use strict";

    angular.module('app.controllers').controller('ClienteEditController', ClienteEditController);
    ClienteEditController.$inject = ['$scope', '$state', 'ClienteService', 'AlertService'];

    function ClienteEditController($scope, $state, ClienteService, AlertService) {

        $scope.Dto = {};

        $scope.update = function () {
            ClienteService.Update($scope.Dto, function (data) {
                $state.go('cliente');
                AlertService.addSuccess("Cliente alterado com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };

        function load() {
            ClienteService.GetById($state.params.id, function (data) {
                $scope.Dto = data
            }, function (error) { AlertService.addError(error.message); });
        }
        load();
    }
})();