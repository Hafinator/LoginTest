test.controller('secretCtrl', function ($scope, $http, $state) {

	$scope.name = '';
	$scope.surname = '';
	$scope.age = '';
	$scope.address = '';

	(function () {
		var returnedData = GetSecret();
	})();


	function GetSecret() {
		return $http.get('/user/secret').then(function (response) {//, document.cookie, { withCredentials: true }

			//Extract(response.data);
			var temp = response.data;
			$scope.name = temp.name;
			$scope.surname = temp.surname;
			$scope.age = temp.age;
			$scope.address = temp.address;

		});
	};
	//function Extract(data) {
	//	var 
	//}



	$scope.Back = function () {
		$state.go('home');
	};
});
