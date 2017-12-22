var routes = angular.module('app.routes', []);

routes.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: 'Templates/login.html',
            controller: 'LoginCtrl',
            controllerAs: 'login'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'Templates/home.html',
            controller: 'HomeController',
            controllerAs: 'home'
        })
        .state('categoria', {
            url: '/categoria',
            templateUrl: 'Templates/categoria/categoria.lista.html',
            controller: 'CategoriaListaController',
            controllerAs: 'categoria'
        })
        .state('categorianew', {
            url: '/categoria/new',
            templateUrl: 'Templates/categoria/categoria.new.html',
            controller: 'CategoriaNewController',
            controllerAs: 'categorianew'
        })
        .state('categoriaedit', {
            url: '/categoria/edit/:id',
            templateUrl: 'Templates/categoria/categoria.edit.html',
            controller: 'CategoriaEditController',
            controllerAs: 'categoriaedit'
        })
        .state('cliente', {
            url: '/cliente',
            templateUrl: 'Templates/cliente/cliente.lista.html',
            controller: 'ClienteListaController',
            controllerAs: 'cliente'
        })
        .state('clientenew', {
            url: '/cliente/new',
            templateUrl: 'Templates/cliente/cliente.new.html',
            controller: 'ClienteNewController',
            controllerAs: 'clientenew'
        })
        .state('clienteedit', {
            url: '/cliente/edit/:id',
            templateUrl: 'Templates/cliente/cliente.edit.html',
            controller: 'ClienteEditController',
            controllerAs: 'clienteedit'
        })
        .state('produto', {
            url: '/produto',
            templateUrl: 'Templates/produto/produto.lista.html',
            controller: 'ProdutoListaController',
            controllerAs: 'produto'
        })
        .state('produtonew', {
            url: '/produto/new',
            templateUrl: 'Templates/produto/produto.new.html',
            controller: 'ProdutoNewController',
            controllerAs: 'produtonew'
        })
        .state('produtoedit', {
            url: '/produto/edit/:id',
            templateUrl: 'Templates/produto/produto.edit.html',
            controller: 'ProdutoEditController',
            controllerAs: 'produtoedit'
        })
        .state('accessdenied', {
            url: '/accessdenied',
            templateUrl: 'Templates/accessDenied.html',
            controller: 'AccessDeniedController',
            controllerAs: 'accessdenied'
        });

    $urlRouterProvider.otherwise('/home');
}]);

routes.run(function ($rootScope, $state, UserService, AlertService) {
    //TODO: Verify if user has permission to access the next route
    
    $rootScope.$on('$stateChangeStart', function (event, next, nextParams, fromState) {
        AlertService.cleanAlerts();
        if (!UserService.isAuthenticated()) {
            if (next.name !== 'login' && next.name !== 'accessdenied') {
                event.preventDefault();
                $state.go('accessdenied');
            }
        }
    });
})