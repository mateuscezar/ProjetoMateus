(function () {
    "use strict";

    angular.module('app.controllers').controller('ClienteNewController', ClienteNewController);
    ClienteNewController.$inject = ['$scope', '$state', 'ClienteService', 'AlertService'];

    function ClienteNewController($scope, $state, ClienteService, AlertService) {

        $scope.Dto = {};

        $scope.save = function () {
            ClienteService.Save($scope.Dto, function (data) {
                $state.go('cliente');
                AlertService.addSuccess("Cliente inserido com sucesso.");
            }, function (error) { AlertService.addError(error.message); });
        };
    }
})();