test.controller('loginCtrl', function ($scope, $state) {

	$scope.Back = function () {
		$state.go('home');
	};
	$scope.GoTo = function () {
		$state.go('secret');
	};
});
