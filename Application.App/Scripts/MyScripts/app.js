var app = angular.module('myApp', []);
app.controller('myController', function ($scope, $http) {
    var dataType = 'json';
    var config = { headers: { "Content-Type": "application/json" } };
    $scope.AmountChange = function () {
        if (!isNaN($scope.amount)) {
            var ch = $scope.amount.substr($scope.amount.length - 1);
            if (ch !== '-' || ch !== '.') {
                $http.get('http://localhost:30450/conversion?number=' + $scope.amount, config, dataType)
                    .then(function success(response) {
                        if (response != null) {
                            $scope.response = response.data;
                        }
                        else {
                            $scope.response = 0;
                        }
                    }, function error(response) {
                        $scope.response = 0;
                    })
            }
        }
        else {
            $scope.response = 'Invalid Number';
        }
    };
});