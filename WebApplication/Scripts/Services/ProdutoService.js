(function () {
    "use strict";

    angular.module('app.services').service('ProdutoService', ProdutoService);

    function ProdutoService($http, AUTHENTICATONSERVER_URI) {

        return {
            GetAll: function (sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Produto').then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Delete: function (id, sucess, error) {
                $http.delete(AUTHENTICATONSERVER_URI + 'Produto/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Save: function (dto, sucess, error) {
                $http.post(AUTHENTICATONSERVER_URI + 'Produto', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            GetById: function (id, sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Produto/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Update: function (dto, sucess, error) {
                $http.put(AUTHENTICATONSERVER_URI + 'Produto', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            }
        };

    }
})();