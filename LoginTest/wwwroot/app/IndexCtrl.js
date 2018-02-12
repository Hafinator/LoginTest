test.controller('indexCtrl', function ($scope, $http, $state) {

	$scope.welcome = 'Greetings';
	$scope.userName = '';
	$scope.password = '';

	(function () {

	})();

	$scope.click = function () {
		return $http.post('/user/login/' + $scope.userName + '/' + $scope.password).then(function (response) {
			if (response.data) {
				$scope.LogedIn();
			}
			else {
				$scope.Wrong();
			}
			return response.data;
		});
	};
	$scope.LogedIn = function () {
		$state.go('logedIn');
	};
	$scope.Wrong = function () {
		$state.go('wrong');
	};
});
