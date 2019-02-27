/// <reference path="angular.js" />

var app = angular.module("myApp", []);

app.controller("ProductCtrl", function($scope) {
    $scope.urunler = [];
    function init() {
        var data = JSON.parse(localStorage.getItem("urunler"));
        $scope.urunler = data === null ? [] : data;
    }

    $scope.ekle = function() {
        $scope.urunler.push({
            urunAdi: $scope.yeni.urunAdi,
            fiyat: $scope.yeni.fiyat,
            eklenmeZamani: new Date()
        });
        $scope.yeni.urunAdi = "";
        $scopeyeni.yeni.fiyat = "";
        localStorage.setItem("urunler",JSON.stringify($scope.urunler));
    };

    init();
});