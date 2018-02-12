test.controller('wrongCtrl', function ($scope, $state) {

	(function () {

	})();

	$scope.Back = function () {
		$state.go('home');
	};
});
