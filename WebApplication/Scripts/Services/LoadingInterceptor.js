﻿(function () {
    "use strict";

    angular.module('app.services').service('LoadingInterceptor', LoadingInterceptor);
    LoadingInterceptor.$inject = ['$q', '$rootScope', '$log'];

    function LoadingInterceptor($q, $rootScope, $log) {

        var numLoadings = 0;

        return {
            request: function (config) {

                numLoadings++;

                // Show loader
                $rootScope.$broadcast("loader_show");
                return config || $q.when(config)

            },
            response: function (response) {

                if ((--numLoadings) === 0) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                return response || $q.when(response);

            },
            responseError: function (response) {

                if (!(--numLoadings)) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                return $q.reject(response);
            }
        };

    }
})();