angular
    .module("master", [])
    .controller("masterController", masterController);
angular.injector = ["$scope", "$http"];
function masterController($scope, $http) {
    $scope.employees = [];
    $scope.employee = {};
    $scope.error = "";
    $scope.action = "Create";

    $http.get("Employee/AllEmployee").then(
        function (response) {
            angular.forEach(response.data, function (data, key) {
                $scope.employees.push(data);
            });
        },
        function (response) {
            $scope.error = response.data;
        });

    $scope.clear = function () {
        $scope.employee = {};
        $scope.action = "Create";
    }

    $scope.getEmployeeById = function (empID) {
        $http.get("Employee/GetEmployee/" + $scope.employee.id).then(
            function (response) {
                $scope.employee = response.data;
            },
            function (response) {
                $scope.error = response.data;
            });
    };

    $scope.saveEmployee = function () {
        $http.post("Employee/SaveEmployee", $scope.employee).then(
            function (response) {
                $scope.employees = [];
                $scope.employee = {};
                angular.forEach(response.data, function (data, key) {
                    $scope.employees.push(data);
                });
            },
            function (response) {
                $scope.error = response.data;
            });
    };

    $scope.updateEmployee = function () {
        $http.post("Employee/UpdateEmployee", $scope.employee).then(
            function (response) {
                $scope.employees = [];
                $scope.employee = {};
                angular.forEach(response.data, function (data, key) {
                    $scope.employees.push(data);
                });
            },
            function (response) {
                $scope.error = response.data;
            });
    };

    $scope.removeEmployee = function (employee) {
        $http.post("Employee/RemoveEmployee", employee).then(
            function (response) {
                $scope.employees = [];
                $scope.employee = {};
                angular.forEach(response.data, function (data, key) {
                    $scope.employees.push(data);
                });
            },
            function (response) {
                $scope.error = response.data;
            });
    };

    $scope.editEmployee = function (id) {
        $http.get("Employee/EmployeeByID/"+ id).then(
            function (response) {
                $scope.employee.Id = response.data.Id;
                $scope.employee.FirstName = response.data.FirstName;
                $scope.employee.MiddleName = response.data.MiddleName;
                $scope.employee.LastName = response.data.LastName;
                $scope.employee.Gender = response.data.Gender;
                $scope.employee.DateOfBirth = response.data.DateOfBirth;
                $scope.employee.MaritalStatus = response.data.MaritalStatus;
                $scope.employee.Address = response.data.Address;
                $scope.employee.City = response.data.City;
                $scope.action = "Update";
            },
            function (response) {
                $scope.error = response.data;
            });
    };

    //$scope.$watch($scope.employee, function ($scope) { return $scope.employee; },
    //    function (oldValue, newValue) {
    //    if (oldValue == newValue) {
    //        return;
    //    }
    //    if (oldValue != newValue)
    //    {
    //        $scope.employee.firstName = newValue.firstName;
    //        $scope.$digest();
    //    }
    //}, true);

}