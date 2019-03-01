﻿/// <reference path="angular.js" />

var app = angular.module("myApp", []);
var host = "http://localhost:5855/";
app.controller("ProductCtrl", function ($scope) {
    $scope.urunler = [];
    $scope.sepetList = [];
    $scope.ekleMi = false;
    $scope.sepetToplam = 0;

    function init() {
        var data = JSON.parse(localStorage.getItem("urunler"));
        $scope.urunler = data === null ? [] : data;
        data = JSON.parse(localStorage.getItem("sepet"));
        $scope.sepetList = data === null ? [] : data;
        sepetHesapla();
    }
    $scope.ekle = function () {
        $scope.urunler.push({
            id: guid(),
            urunAdi: $scope.yeni.urunAdi,
            fiyat: $scope.yeni.fiyat,
            eklenmeZamani: new Date()
        });
        $scope.yeni.urunAdi = "";
        $scope.yeni.fiyat = "";
        localStorage.setItem("urunler", JSON.stringify($scope.urunler));
    };

    $scope.sil = function (id) {
        for (var i = 0; i < $scope.urunler.length; i++) {
            var data = $scope.urunler[i];
            if (id === data.id) {
                $scope.urunler.splice(i, 1);
                break;
            }
        }
        localStorage.setItem("urunler", JSON.stringify($scope.urunler));
    };

    $scope.sepeteekle = function (urun) {
        var varMi = false;
        for (var i = 0; i < $scope.sepetList.length; i++) {
            var data = $scope.sepetList[i];
            if (data.id === urun.id) {
                varMi = true;
                data.adet++;
                break;
            }
        }
        if (!varMi) {
            urun.adet = 1;
            $scope.sepetList.push(urun);
        }
        localStorage.setItem("sepet", JSON.stringify($scope.sepetList));
        sepetHesapla();
    };

    function sepetHesapla() {
        $scope.sepetToplam = 0;
        for (var i = 0; i < $scope.sepetList.length; i++) {
            var data = $scope.sepetList[i];
            $scope.sepetToplam += data.adet * data.fiyat;
        }
    }

    $scope.cikart = function (urun) {
        var index = $scope.sepetList.indexOf(urun);
        if (index > -1)
            $scope.sepetList.splice(index, 1);
        localStorage.setItem("sepet", JSON.stringify($scope.sepetList));
        sepetHesapla();
    };

    function guid() {
        function S4() {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        }

        // then to call it, plus stitch in '4' in the third group
        return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
    }

    init();
});
app.controller("CategoryCtrl", function ($scope, $http) {
    $scope.categoryList = [];
    $scope.istekVarMi = false;

    function init() {
        $scope.istekVarMi = true;
        $http({
            method: 'GET',
            url: host + "api/category/getall"
        }).then(function successCallback(response) {
            $scope.istekVarMi = false;
            var r = response.data;
            if (r.success) {
                $scope.categoryList = r.data;
            } else {
                alert(r.message);
            }
        }, function errorCallback(response) {
            $scope.istekVarMi = false;
            console.log(response);
        });
    }

    $scope.ekle = function () {
        $scope.istekVarMi = true;
        $http({
            method: "POST",
            url: host + "api/category/add",
            data: $scope.yeni
        }).then(function (rs) {
            $scope.istekVarMi = false;
            if (rs.data.success) {
                alert(rs.data.message);
                init();
            } else {
                alert("bir hata oluştu " + rs.data.message);
            }
        },
            function (re) {
                $scope.istekVarMi = false;
            });
    };

    init();
});