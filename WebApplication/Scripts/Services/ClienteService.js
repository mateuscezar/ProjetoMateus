(function () {
    "use strict";

    angular.module('app.services').service('ClienteService', ClienteService);

    function ClienteService($http, AUTHENTICATONSERVER_URI) {

        return {
            GetAll: function (sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Cliente').then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Delete: function (id, sucess, error)
            {
                $http.delete(AUTHENTICATONSERVER_URI + 'Cliente/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Save: function (dto, sucess, error) {
                $http.post(AUTHENTICATONSERVER_URI + 'Cliente', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            GetById: function (id, sucess, error) {
                $http.get(AUTHENTICATONSERVER_URI + 'Cliente/' + id).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            },
            Update: function (dto, sucess, error) {
                $http.put(AUTHENTICATONSERVER_URI + 'Cliente', dto).then(function (response) { sucess(response.data); }).catch(function (response) { error(response.data); });
            }
        };

    }
})();