var test = angular.module('test', ['ui.router', 'ui.router.stateHelper','ngCookies']);

test.config(['$stateProvider', '$urlRouterProvider', '$httpProvider', function ($stateProvider, $urlRouterProvider, $httpProvider) {
	$stateProvider
		.state('wrong', {
			url: '/wrong',
			templateUrl: '/wrong.html'
		})
		.state('home', {
			url: '/home',
			templateUrl: '/home.html'
		})
		.state('logedIn', {
			url: '/logedIn',
			templateUrl: '/logedIn.html'
		})
		.state('secret', {
			url: '/secret',
			templateUrl: '/secret.html'
		});

	$urlRouterProvider.otherwise('/home');

	//$httpProvider.defaults.withCredentials = true;
}]);
//test.run(['$http', '$cookies', function ($http, $cookies) {
//		$http.defaults.headers.post['X-CSRFToken'] = $cookies.csrftoken;
//	}]);