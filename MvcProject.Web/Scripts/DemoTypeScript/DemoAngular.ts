﻿//http://stackoverflow.com/questions/31541023/typescript-functions-with-attributes
interface IStatefulFunction {
    (): string;
    $stateful: boolean;
}

interface IMyService {
    GetData: Function
}

angular.module('mvcApp', ['ngResource'])
    .filter('eTon', ['myService', function (myService: IMyService) {
        //http://stackoverflow.com/questions/19046641/angularjs-asynchronously-initialize-filter
        var data = null, serviceInvoked = false;

        function realFilter(value) {
            if (data.name === value) {
                return "1";
            }
            return value;
        }
        
        var translateFilter = <IStatefulFunction>function (input) {
            if (data === null) {
                if (!serviceInvoked) {
                    serviceInvoked = true;
                    myService.GetData().then(function (response) {
                        data = response;
                    }, function () {
                        data = null;
                    });
                }
                return input;
            }
            else {
                return realFilter(input)
            };
        };

        translateFilter.$stateful = true;

        return translateFilter;
    }])
    .factory('myService', function ($http: ng.IHttpService, $q: ng.IQService) {
        function GetData() {
            var deffered = $q.defer();
            $http.get('/Home/GetMockData')
                .then(function (response) {
                    deffered.resolve(response.data);
                }, function (response) {
                    deffered.reject(response);
                })
            return deffered.promise;
        }
        return {
            GetData: GetData
        }

    })
    .controller('myCtrl', ['$scope', 'myService', function ($scope, myService) {
        $scope.title = 'DemoAngular';
        $scope.data = 'one';
    }]);