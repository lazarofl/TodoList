function TodoListController($scope, $http) {

    $scope.todoList = [];

    $scope.GetAll = function () {
        $http.get('/Home/GetAll').success(function (todolist) {
            console.log(todolist);
            $scope.todoList = todolist;
        });
    }

    $scope.Add = function () {
        $http.post('/Home/Add', { name: $scope.name }).success(function (todo) {
            $scope.todoList.splice(0, 0, todo);
            $scope.name = "";
        });
    }

    $scope.Toggle = function (item) {
        $http.post('/Home/Done', { id: item.Id, done: !item.Done });
    }


}