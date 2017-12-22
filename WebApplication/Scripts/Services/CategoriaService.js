(function () {
    "use strict";

    angular.module('app.services').service('CategoriaService', CategoriaService);

    function CategoriaService($http, AUTHENTICATONSERVER_URI) {

        return {
            GetAll: function (sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Categoria').then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Delete: function (id, sucess, error) {
                $http.delete(AUTHENTICATONSERVER_URI + 'Categoria/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Save: function (dto, sucess, error) {
                $http.post(AUTHENTICATONSERVER_URI + 'Categoria', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            GetById: function (id, sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Categoria/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Update: function (dto, sucess, error) {
                $http.put(AUTHENTICATONSERVER_URI + 'Categoria', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            }
        };

    }
})();